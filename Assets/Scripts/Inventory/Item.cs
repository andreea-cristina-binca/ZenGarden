using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Pot,
        Seeds,
        SmallShovel,
        SmallFork
    }
    
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Pot:          return ItemAssets.Instance.potSprite;
            case ItemType.Seeds:        return ItemAssets.Instance.seedsSprite;
            case ItemType.SmallShovel:  return ItemAssets.Instance.smallShovelSprite;
            case ItemType.SmallFork:    return ItemAssets.Instance.smallForkSprite;   
        }
    }

}
