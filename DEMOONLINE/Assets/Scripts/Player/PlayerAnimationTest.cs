using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float Yinput;
    public float Xinput;
    public bool isIdle;
    public bool isWalking;
    public ToolEffect toolEffect;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isAxingToolRight;
    public bool isAxingToolLeft;
    public bool isAxingToolUp;
    public bool isAxingToolDown;
    public bool isPickAxingToolRight;
    public bool isPickAxingToolLeft;
    public bool isPickAxingToolUp;
    public bool isPickAxingToolDown;
    public bool isPickingUpRight;
    public bool isPickingUpLeft;
    public bool isPickingUpUp;
    public bool isPickingUpDown;
    public bool isWateringToolRight;
    public bool isWateringToolLeft;
    public bool isWateringToolUp;
    public bool isWateringToolDown;
    public bool idleRight;
    public bool idleLeft;
    public bool idleUp;
    public bool idleDown;

    private void Update()
    {
        EventHandler.CallMovementEvent(Yinput, Xinput, isWalking, isIdle, toolEffect,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isAxingToolRight, isAxingToolLeft, isAxingToolUp, isAxingToolDown,
            isPickAxingToolRight, isPickAxingToolLeft, isPickAxingToolUp, isPickAxingToolDown,
            isPickingUpRight, isPickingUpLeft, isPickingUpUp, isPickingUpDown,
            isWateringToolRight, isWateringToolLeft, isWateringToolUp, isWateringToolDown,
            idleRight, idleLeft, idleUp, idleDown);
    }
}
