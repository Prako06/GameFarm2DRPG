using System;
using System.Collections.Generic;

public delegate void MovementDelegate(float inputX, float inputY, bool isWalking, bool isIdle, ToolEffect toolEffect,
bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
bool isAxingToolRight, bool isAxingToolLeft, bool isAxingToolUp, bool isAxingToolDown,
bool isPickAxingToolRight, bool isPickAxingToolLeft, bool isPickAxingToolUp, bool isPickAxingToolDown,
bool isPickingUpRight, bool isPickingUpLeft, bool isPickingUpUp, bool isPickingUpDown,
bool isWateringToolRight, bool isWateringToolLeft, bool isWateringToolUp, bool isWateringToolDown,
bool idleRight, bool idleLeft, bool idleUp, bool idleDown);

public static class EventHandler
{
    // Inventory Updated Event
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (InventoryUpdatedEvent != null)
        {
            InventoryUpdatedEvent(inventoryLocation, inventoryList);
        }
    }

    // Movement Event

    public static MovementDelegate MovementEvent;

    // Movement Event call for Publisher

    public static void CallMovementEvent(float inputX, float inputY, bool isWalking, bool isIdle, ToolEffect toolEffect,
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
    bool isAxingToolRight, bool isAxingToolLeft, bool isAxingToolUp, bool isAxingToolDown,
    bool isPickAxingToolRight, bool isPickAxingToolLeft, bool isPickAxingToolUp, bool isPickAxingToolDown,
    bool isPickingUpRight, bool isPickingUpLeft, bool isPickingUpUp, bool isPickingUpDown,
    bool isWateringToolRight, bool isWateringToolLeft, bool isWateringToolUp, bool isWateringToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown)
    {
        if (MovementEvent != null)
        {
            MovementEvent(inputX, inputY, isWalking, isIdle, toolEffect,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isAxingToolRight, isAxingToolLeft, isAxingToolUp, isAxingToolDown,
            isPickAxingToolRight, isPickAxingToolLeft, isPickAxingToolUp, isPickAxingToolDown,
            isPickingUpRight, isPickingUpLeft, isPickingUpUp, isPickingUpDown,
            isWateringToolRight, isWateringToolLeft, isWateringToolUp, isWateringToolDown,
            idleRight, idleLeft, idleUp, idleDown);
        }
    }
}
