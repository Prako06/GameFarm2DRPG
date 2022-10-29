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

    // Time Events

    // Advance game minute
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameMinuteEvent;

    public static void CallAdvanceGameMinuteEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int
     gameSecond)
    {
        if (AdvanceGameMinuteEvent != null)
        {
            AdvanceGameMinuteEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    // Advance game hour
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameHourEvent;

    public static void CallAdvanceGameHourEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int
     gameSecond)
    {
        if (AdvanceGameHourEvent != null)
        {
            AdvanceGameHourEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    // Advance game day
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameDayEvent;

    public static void CallAdvanceGameDayEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int
     gameSecond)
    {
        if (AdvanceGameDayEvent != null)
        {
            AdvanceGameDayEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    // Advance game season
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameSeasonEvent;

    public static void CallAdvanceGameSeasonEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int
     gameSecond)
    {
        if (AdvanceGameSeasonEvent != null)
        {
            AdvanceGameSeasonEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    // Advance game year
    public static event Action<int, Season, int, string, int, int, int> AdvanceGameYearEvent;

    public static void CallAdvanceGameYearEvent(int gameYear, Season gameSeason, int gameDay, string gameDayOfWeek, int gameHour, int gameMinute, int
     gameSecond)
    {
        if (AdvanceGameYearEvent != null)
        {
            AdvanceGameYearEvent(gameYear, gameSeason, gameDay, gameDayOfWeek, gameHour, gameMinute, gameSecond);
        }
    }

    // Scene Load Events - in the oder they happen

    // Before Scene Unload Fade out Event
    public static event Action BeforeSceneUnloadFadeOutEvent;

    public static void CallBeforeSceneUnloadFadeOutEvent()
    {
        if (BeforeSceneUnloadFadeOutEvent != null)
        {
            BeforeSceneUnloadFadeOutEvent();
        }
    }

    //Before Scene Unload Event
    public static event Action BeforeSceneUnloadEvent;

    public static void CallBeforeSceneUnloadEvent()
    {
        if (BeforeSceneUnloadEvent != null)
        {
            BeforeSceneUnloadEvent();
        }
    }

    // After Scene Loaded Event
    public static event Action AfterSceneLoadEvent;

    public static void CallAfterSceneLoadEvent()
    {
        if (AfterSceneLoadEvent != null)
        {
            AfterSceneLoadEvent();
        }
    }

    // After Scene Load Fade In Event
    public static event Action AfterSceneLoadFadeInEvent;

    public static void CallAfterSceneLoadFadeInEvent()
    {
        if (AfterSceneLoadFadeInEvent != null)
        {
            AfterSceneLoadFadeInEvent();
        }
    }
}
