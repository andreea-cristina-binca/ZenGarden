using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames.InventorySystem;
using DevionGames.UIWidgets;
public class TabletUI : MonoBehaviour
{
    [SerializeField] private GameObject tabletUI;
    [SerializeField] private GameObject vendorTab;
    [SerializeField] private GameObject challengesTab;
    [SerializeField] private GameObject musicTab;

    private bool isActive;

    private void Start()
    {
        tabletUI.GetComponent<UIWidget>().Close();
        
        vendorTab.SetActive(false);
        challengesTab.SetActive(false);
        musicTab.SetActive(false);
        
        isActive = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (isActive)
            {
                tabletUI.GetComponent<UIWidget>().Close();
                Cursor.visible = false;

                vendorTab.SetActive(false);
                challengesTab.SetActive(false);
                musicTab.SetActive(false);

                isActive = false;
            }
            else
            {
                tabletUI.GetComponent<UIWidget>().Show();
                Cursor.visible = true;

                isActive = true;
            }
        }
    }

    public void DeactivateButton()
    {
        isActive = false;
    }
}
