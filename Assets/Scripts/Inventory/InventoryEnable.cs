using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEnable : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool active;

    void Start()
    {
        active = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (active)
                player.SetActive(false);
            else
                player.SetActive(true);
        }
    }
}
