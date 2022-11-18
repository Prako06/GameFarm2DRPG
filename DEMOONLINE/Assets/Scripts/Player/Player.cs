using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
    private WaitForSeconds afterUseToolAnimationPause;
    private AnimationOverrides animationOverrides;
    private GridCursor gridCursor;
    // Movement Parameters
    private float xInput;
    private float yInput;
    private bool isWalking;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isUsingToolRight;
    private bool isUsingToolLeft;
    private bool isUsingToolUp;
    private bool isUsingToolDown;
    private bool isAxingToolRight;
    private bool isAxingToolLeft;
    private bool isAxingToolUp;
    private bool isAxingToolDown;
    private bool isPickAxingToolRight;
    private bool isPickAxingToolLeft;
    private bool isPickAxingToolUp;
    private bool isPickAxingToolDown;
    private bool isPickingUpRight;
    private bool isPickingUpLeft;
    private bool isPickingUpUp;
    private bool isPickingUpDown;
    private bool isWateringToolRight;
    private bool isWateringToolLeft;
    private bool isWateringToolUp;
    private bool isWateringToolDown;

    private Camera mainCamera;

    private bool playerToolUseDisable = false;

    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidbody2D;

    private WaitForSeconds useToolAnimationPause;

    private Direction playerDirection;

    private List<CharacterAttribute> characterAttributeCustomisationList;
    private float movementSpeed;

    [Tooltip("Should be populated in the prefab with the equipped item sprite renderer")]
    [SerializeField] private SpriteRenderer equippedItemSpriteRenderer = null;

    // Player attributes that can be swapped
    private CharacterAttribute bodyCharacterAttribute;
    private CharacterAttribute hairCharacterAttribute;
    private CharacterAttribute clothesCharacterAttribute;
    private CharacterAttribute toolCharacterAttribute;

    private bool _playerInputIsDisable = false;

    public bool PlayerInputIsDisable { get => _playerInputIsDisable; set => _playerInputIsDisable = value; }

    protected override void Awake()
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();

        animationOverrides = GetComponentInChildren<AnimationOverrides>();

        // Initialise swappable character attributes
        bodyCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.Body, PartVariantColour.none, PartVariantType.none);
        hairCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.Hair, PartVariantColour.none, PartVariantType.none);
        clothesCharacterAttribute = new CharacterAttribute(CharacterPartAnimator.Clothes, PartVariantColour.none, PartVariantType.none);

        // Initialise character attribute list
        characterAttributeCustomisationList = new List<CharacterAttribute>();

        mainCamera = Camera.main;
    }

    private void Start()
    {
        gridCursor = FindObjectOfType<GridCursor>();
        useToolAnimationPause = new WaitForSeconds(Settings.useToolAnimationPause);
        afterUseToolAnimationPause = new WaitForSeconds(Settings.afterUseToolAnimationPause);
    }

    private void Update()
    {
        #region Player Input

        if (!PlayerInputIsDisable)
        {
            ResetAnimationTriggers();

            PlayerMovementInput();

            PlayerClickInput();

            PlayerTestInput();


            EventHandler.CallMovementEvent(xInput, yInput, isWalking, isIdle, toolEffect,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isAxingToolRight, isAxingToolLeft, isAxingToolUp, isAxingToolDown,
            isPickAxingToolRight, isPickAxingToolLeft, isPickAxingToolUp, isPickAxingToolDown,
            isPickingUpRight, isPickingUpLeft, isPickingUpUp, isPickingUpDown,
            isWateringToolRight, isWateringToolLeft, isWateringToolUp, isWateringToolDown,
            false, false, false, false);
        }

        #endregion Player Input
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + move);
    }

    private void ResetAnimationTriggers()
    {
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isUsingToolUp = false;
        isUsingToolUp = false;
        toolEffect = ToolEffect.none;
    }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        if (yInput != 0 && xInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if (xInput != 0 || yInput != 0)
        {
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;

            if (xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if (xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if (yInput < 0)
            {
                playerDirection = Direction.down;
            }
            else
            {
                playerDirection = Direction.up;
            }
        }

        else if (xInput == 0 && yInput == 0)
        {
            isWalking = false;
            isIdle = true;
        }
    }

    private void PlayerClickInput()
    {
        if (!playerToolUseDisable)
        {
            if (Input.GetMouseButton(0))
            {
                if (gridCursor.CursorIsEnable)
                {
                    Vector3Int cursorGridPosition = gridCursor.GetGridPositionForCursor();

                    Vector3Int playerGridPosition = gridCursor.GetGridPositionForPlayer();

                    ProcessPlayerClickInput(cursorGridPosition, playerGridPosition);
                }
            }
        }
    }

    private void ProcessPlayerClickInput(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        ResetMovement();

        Vector3Int playerDirection = GetPlayerClickDirection(cursorGridPosition, playerGridPosition);

        GridPropertyDetails gridPropertyDetails = GridPropertiesManager.Instance.GetGridPropertyDetails(cursorGridPosition.x, cursorGridPosition.y);

        //Get selected itemDetails 
        ItemDetails itemDetails = InventoryManager.Instance.GetSelectedInventoryItemDetails(InventoryLocation.player);

        if (itemDetails != null)
        {
            switch (itemDetails.itemType)
            {
                case ItemType.Seed:
                    if (Input.GetMouseButtonDown(0))
                    {
                        ProcessPlayerClickInputSeed(itemDetails);
                    }
                    break;

                case ItemType.Commodity:
                    if (Input.GetMouseButtonDown(0))
                    {
                        ProcessPlayerClickInputCommodity(itemDetails);
                    }
                    break;

                case ItemType.Hoeing_tool:
                    ProcessPlayerClickInputTool(gridPropertyDetails, itemDetails, playerDirection);
                    break;

                case ItemType.none:
                    break;

                case ItemType.count:
                    break;

                default:
                    break;
            }
        }
    }

    private Vector3Int GetPlayerClickDirection(Vector3Int cursorGridPosition, Vector3Int playerGridPosition)
    {
        if (cursorGridPosition.x > playerGridPosition.x)
        {
            return Vector3Int.right;
        }
        else if (cursorGridPosition.x < playerGridPosition.x)
        {
            return Vector3Int.left;
        }
        else if (cursorGridPosition.y > playerGridPosition.y)
        {
            return Vector3Int.up;
        }
        else 
        {
            return Vector3Int.down;
        }
    }

    private void ProcessPlayerClickInputSeed(ItemDetails itemDetails)
    {
        if (itemDetails.canBeDropped)
        {
            EventHandler.CallDropSelectedItemEvent();
        }
    }

    private void ProcessPlayerClickInputCommodity(ItemDetails itemDetails)
    {
        if (itemDetails.canBeDropped)
        {
            EventHandler.CallDropSelectedItemEvent();
        }
    }

    private void ProcessPlayerClickInputTool(GridPropertyDetails gridPropertyDetails, ItemDetails itemDetails, Vector3Int playerDirection)
    {
        switch (itemDetails.itemType)
        {
            case ItemType.Hoeing_tool:
                if (gridCursor.CursorPostionIsValid)
                {
                    HoeGroundAtCursor(gridPropertyDetails, playerDirection);
                }
                break;

            default:
                break;
        }
    }

    private void HoeGroundAtCursor(GridPropertyDetails gridPropertyDetails, Vector3Int playerDirection)
    {
        StartCoroutine(HoeGroundAtCursorRoutine(playerDirection, gridPropertyDetails));
    }

    private IEnumerator HoeGroundAtCursorRoutine(Vector3Int playerDirection, GridPropertyDetails gridPropertyDetails)
    {
        PlayerInputIsDisable = true;
        playerToolUseDisable = true;

        toolCharacterAttribute.partVariantType = PartVariantType.hoe;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(toolCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        if (playerDirection == Vector3Int.right)
        {
            isUsingToolRight = true;
        }
        else if (playerDirection == Vector3Int.left)
        {
            isUsingToolLeft = true;
        }
        else if (playerDirection == Vector3Int.up)
        {
            isUsingToolUp = true;
        }
        else if (playerDirection == Vector3Int.down)
        {
            isUsingToolDown = true;
        }

        yield return useToolAnimationPause;

        if (gridPropertyDetails.daysSinceDug == -1)
        {
            gridPropertyDetails.daysSinceDug = 0;
        }

        GridPropertiesManager.Instance.SetGridPropertyDetails(gridPropertyDetails.gridX, gridPropertyDetails.gridY, gridPropertyDetails);

        GridPropertiesManager.Instance.DisplayDugGround(gridPropertyDetails);

        yield return afterUseToolAnimationPause;

        isUsingToolDown = false;
        PlayerInputIsDisable = false;
        playerToolUseDisable = false;
    }


    private void PlayerTestInput()
    {
        // Trigger Advance Time
        if (Input.GetKey(KeyCode.T))
        {
            TimeManager.Instance.TestAdvanceGameMinute();
        }

        // Trigger Advance Day
        if (Input.GetKeyDown(KeyCode.G))
        {
            TimeManager.Instance.TestAdvanceGameDay();
        }

        // Test scene unload / load
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneControllerManager.Instance.FadeAndLoadScene(SceneName.GamePlay1_Farm.ToString(), transform.position);
        }
    }


    private void ResetMovement()
    {
        xInput = 0f;
        yInput = 0f;
        isWalking = false;
        isIdle = true;
    }

    public void DisablePlayerInputAndResetMovement()
    {
        DisablePlayerInput();
        ResetMovement();

        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isIdle, toolEffect,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isAxingToolRight, isAxingToolLeft, isAxingToolUp, isAxingToolDown,
            isPickAxingToolRight, isPickAxingToolLeft, isPickAxingToolUp, isPickAxingToolDown,
            isPickingUpRight, isPickingUpLeft, isPickingUpUp, isPickingUpDown,
            isWateringToolRight, isWateringToolLeft, isWateringToolUp, isWateringToolDown,
            false, false, false, false);
    }

    public void DisablePlayerInput()
    {
        PlayerInputIsDisable = true;
    }

    public void EnablePlayerInput()
    {
        PlayerInputIsDisable = false;
    }

    public void ClearCarriedItem()
    {
        equippedItemSpriteRenderer.sprite = null;
        equippedItemSpriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        // Apply base character body customisation
        bodyCharacterAttribute.partVariantType = PartVariantType.none;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(bodyCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        // Apply base character hair customisation
        hairCharacterAttribute.partVariantType = PartVariantType.none;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(hairCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        // Apply base character clothes customisation
        clothesCharacterAttribute.partVariantType = PartVariantType.none;
        characterAttributeCustomisationList.Clear();
        characterAttributeCustomisationList.Add(clothesCharacterAttribute);
        animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

        isCarrying = false;
    }

    public void ShowCarriedItem(int itemCode)
    {
        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);
        if (itemDetails != null)
        {
            equippedItemSpriteRenderer.sprite = itemDetails.itemSprite;
            equippedItemSpriteRenderer.color = new Color(1f, 1f, 1f, 1f);

            // Apply 'carry' character body customisation
            bodyCharacterAttribute.partVariantType = PartVariantType.carry;
            characterAttributeCustomisationList.Clear();
            characterAttributeCustomisationList.Add(bodyCharacterAttribute);
            animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

            // Apply 'carry' character hair customisation
            hairCharacterAttribute.partVariantType = PartVariantType.carry;
            characterAttributeCustomisationList.Clear();
            characterAttributeCustomisationList.Add(hairCharacterAttribute);
            animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

            // Apply 'carry' character clothes customisation
            clothesCharacterAttribute.partVariantType = PartVariantType.carry;
            characterAttributeCustomisationList.Clear();
            characterAttributeCustomisationList.Add(clothesCharacterAttribute);
            animationOverrides.ApplyCharacterCustomisationParameters(characterAttributeCustomisationList);

            isCarrying = true;
        }
    }

    public Vector3 GetPlayerViewportPosition()
    {
        return mainCamera.WorldToViewportPoint(transform.position);
    }
}
