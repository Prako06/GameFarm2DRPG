using UnityEngine;

public class Settings
{
    // Obscuring Item Fading - ObscuringItemFader
    public const float fadeInseconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;

    // Inventory
    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;

    // Player Movement
    public const float walkingSpeed = 3.666f;
    // Player Animation Parameters
    public static int Yinput;
    public static int Xinput;
    public static int isWalking;
    public static int isUsingToolRight;
    public static int isUsingToolLeft;
    public static int isUsingToolUp;
    public static int isUsingToolDown;
    public static int isAxingToolRight;
    public static int isAxingToolLeft;
    public static int isAxingToolUp;
    public static int isAxingToolDown;
    public static int isPickAxingToolRight;
    public static int isPickAxingToolLeft;
    public static int isPickAxingToolUp;
    public static int isPickAxingToolDown;
    public static int isPickingUpRight;
    public static int isPickingUpLeft;
    public static int isPickingUpUp;
    public static int isPickingUpDown;
    public static int isWateringToolRight;
    public static int isWateringToolLeft;
    public static int isWateringToolUp;
    public static int isWateringToolDown;

    // Shared Animation Parameters
    public static int idleRight;
    public static int idleLeft;
    public static int idleUp;
    public static int idleDown;

    // Tools
    public const string HoeingTool = "Hoe";
    public const string ChoppingTool = "Axe";
    public const string BreakingTool = "PickAxe";
    public const string WateringTool = "Watering Can";
    public const string CollectingTool = "PickUp";

    //Static constructor
    static Settings()
    {
        // Player Animation Parameters
        Xinput = Animator.StringToHash("Xinput");
        Yinput = Animator.StringToHash("Yinput");
        isWalking = Animator.StringToHash("isWalking");
        isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        isAxingToolRight = Animator.StringToHash("isAxingToolRight");
        isAxingToolLeft = Animator.StringToHash("isAxingToolLeft");
        isAxingToolUp = Animator.StringToHash("isAxingToolUp");
        isAxingToolDown = Animator.StringToHash("isAxingToolDown");
        isPickAxingToolRight = Animator.StringToHash("isPickAxingToolRight");
        isPickAxingToolLeft = Animator.StringToHash("isPickAxingToolLeft");
        isPickAxingToolUp = Animator.StringToHash("isPickAxingToolUp");
        isPickAxingToolDown = Animator.StringToHash("isPickAxingToolDown");
        isPickingUpRight = Animator.StringToHash("isPickingUpRight");
        isPickingUpLeft = Animator.StringToHash("isPickingUpLeft");
        isPickingUpUp = Animator.StringToHash("isPickingUpUp");
        isPickingUpDown = Animator.StringToHash("isPickingUpDown");
        isWateringToolRight = Animator.StringToHash("isWateringToolRight");
        isWateringToolLeft = Animator.StringToHash("isWateringToolLeft");
        isWateringToolUp = Animator.StringToHash("isWateringToolUp");
        isWateringToolDown = Animator.StringToHash("isWateringToolDown");

        // Shared Animation Parameters
        idleRight = Animator.StringToHash("idleRight");
        idleLeft = Animator.StringToHash("idleLeft");
        idleUp = Animator.StringToHash("idleUp");
        idleDown = Animator.StringToHash("idleDown");
    }
}
