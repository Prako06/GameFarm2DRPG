
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
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
    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidbody2D;

    private Direction playerDirection;

    private float movementSpeed;

    private bool _playerInputIsDisable = false;

    public bool PlayerInputIsDisable { get => _playerInputIsDisable; set => _playerInputIsDisable = value;}

    protected override void Awake() 
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        #region Player Input

        ResetAnimationTriggers();

        PlayerMovementInput();

        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isIdle, toolEffect, 
        isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown, 
        isAxingToolRight, isAxingToolLeft, isAxingToolUp, isAxingToolDown,
        isPickAxingToolRight, isPickAxingToolLeft, isPickAxingToolUp, isPickAxingToolDown,
        isPickingUpRight, isPickingUpLeft, isPickingUpUp, isPickingUpDown,
        isWateringToolRight, isWateringToolLeft, isWateringToolUp, isWateringToolDown,
        false,false,false,false);

        #endregion
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
}
