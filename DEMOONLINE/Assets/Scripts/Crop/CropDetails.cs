using UnityEngine;

[System.Serializable]
public class CropDetails 
{
    [ItemCodeDescription]
    public int seedItemCode;
    public int[] growthDays;
    public GameObject[] growthPrefab;
    public Sprite[] growthSprite;
    public Season[] seasons;
    public Sprite harvestedSprite;
    [ItemCodeDescription]
    public int harvestedTransformItemcode;
    public bool hideCropBeforeHarvestedAnimation;
    public bool disableCropCollidersBeforeHarvestedAnimation;
    public bool isHarvestedAnimation;
    public bool isHarvestActionEffect = false;
    public bool spawnCropProducedAtPlayerPosition;
    public HarvestActionEffect harvestActionEffect;

    [ItemCodeDescription]
    public int[] harvestToolItemcode;
    public int[] requiredHarvestActions;
    [ItemCodeDescription]
    public int[] cropProducedItemcode;
    public int[] cropProducedMinQuantity;
    public int[] cropProducedMaxQuantity;
    public int daysToRegrow;


    public bool CanUseToolToHarvestCrop(int toolItemCode)
    {
        if (RequiredHarvestActionsForTool(toolItemCode) == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public int RequiredHarvestActionsForTool(int toolItemCode)
    {
        for ( int i = 0; i < harvestToolItemcode.Length; i++)
        {
            if (harvestToolItemcode[i] == toolItemCode)
            {
                return requiredHarvestActions[i];
            }
        }
        return -1;
    }
}
