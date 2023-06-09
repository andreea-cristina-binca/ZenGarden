using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    
    [SerializeField] private Transform itemSlot;
    [SerializeField] private Transform hotbar;

    public void setInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        Vector3 position = new Vector3(0, 0, 0);

        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlot, hotbar).GetComponent<RectTransform>();
            
            itemSlot.gameObject.SetActive(false);
            itemSlotRectTransform.position += position;
            itemSlot.gameObject.SetActive(true);
            
            position.x += 117;

            Image image = itemSlotRectTransform.Find("itemSprite").GetComponent<Image>();
            image.sprite = item.GetSprite();

            
        }
    }
}
