using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames.InventorySystem;
using DevionGames.UIWidgets;
public class TabletUI : MonoBehaviour
{
    [SerializeField] private GameObject tabletUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject vendorUI;

    private bool isActive;

    private void Start()
    {
        tabletUI.GetComponent<UIWidget>().Close();
        inventoryUI.GetComponent<ItemContainer>().Close();
        vendorUI.GetComponent<ItemContainer>().Close();
        isActive = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (isActive)
            {
                tabletUI.GetComponent<UIWidget>().Close();
                inventoryUI.GetComponent<ItemContainer>().Close();
                vendorUI.GetComponent<ItemContainer>().Close();
                Cursor.visible = false;

                isActive = false;
            }
            else
            {
                tabletUI.GetComponent<UIWidget>().Show();
                inventoryUI.GetComponent<ItemContainer>().Show();
                vendorUI.GetComponent<ItemContainer>().Show();
                Cursor.visible = true;

                isActive = true;
            }
        }
    }
}
