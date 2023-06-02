using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPIckUp : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        // if(Input.GetButtonDown("Interact"))
        {
            float pickUpDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
            {
                // Debug.Log(raycastHit.transform);
                //if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
                //{
                //    showPlant.Interact();
                //}
            }
        }
    }
}
