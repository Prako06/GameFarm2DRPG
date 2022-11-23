public enum AnimationName
{
    idleDown,
    idleUp,
    idleRight,
    idleLeft,
    walkUp,
    walkDown,
    walkRight,
    walkLeft,
    useToolUp,
    useToolDown,
    useToolRight,
    useToolLeft,
    swingToolUp,
    swingToolDown,
    swingToolRight,
    swingToolLeft,
    liftToolUp,
    liftToolDown,
    liftToolRight,
    liftToolLeft,
    holdToolUp,
    holdToolDown,
    holdToolRight,
    holdToolLeft,
    pickDown,
    pickUp,
    pickRight,
    pickLeft,
    count
}

public enum CharacterPartAnimator
{
    Body,
    Hair,
    Clothes,
    tool,
    count
}



public enum PartVariantColour
{
    none,
    count
}

public enum PartVariantType
{
    none,
    carry,
    hoe,
    pickaxe,
    axe,
    wateringCan,
    count
}

public enum GridBoolProperty
{
    digable,
    canDropItem,
    canPlaceFurniture,
    isPath,
    isNPCObstacle
}

public enum InventoryLocation
{
    player,
    chest,
    count
}

public enum SceneName
{
    GamePlay1_Farm,
    GamePlay2_Field,
    GamePlay3_Cabin
}

public enum Season
{
    Spring,
    Summer,
    Autum,
    Winter,
    none,
    count
}

public enum HarvestActionEffect
{
    deciduosLeavesFalling,
    pineConesFalling,
    choppingTreeTrunk,
    breakingStone,
    reaping,
    none
}

public enum ToolEffect
{
    none,
    watering
}

public enum Direction
{
    up,
    down,
    left,
    right,
    none
}

public enum ItemType
{
    Seed,
    Commodity,
    Watering_tool,
    Hoeing_tool,
    Chopping_tool,
    Breaking_tool,
    Reaping_tool,
    Collecting_tool,
    Reapable_scenary,
    Furniture,
    none,
    count
}
