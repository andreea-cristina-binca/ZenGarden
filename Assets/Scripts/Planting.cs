using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask interactLayerMask;

    private bool planted;

    private void Start()
    {
        planted = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
                {
                    if (planted)
                    {
                        Debug.Log("Planted");
                    }
                    else
                    {
                        showPlant.Interact();
                        planted = true;
                    }
                }
            }
        }
    }
}
