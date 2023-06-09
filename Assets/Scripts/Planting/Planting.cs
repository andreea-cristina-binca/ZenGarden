using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private float interactDistance;

    private bool planted;

    private void Start()
    {
        planted = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            float playerHeight = 2.0f;
            float playerRadius = 1.0f;
            
            if(Physics.CapsuleCast(playerTransform.position, playerTransform.position + Vector3.up * playerHeight, playerRadius, playerTransform.forward, out RaycastHit raycast))
            {
                Debug.Log(raycast.transform);
            }
            
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            {
                // Debug.Log(raycastHit.transform);
                if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
                {
                    if (planted)
                    {
                        if (showPlant.Harvest())
                            planted = false;
                    }
                    else
                    {
                        if (showPlant.Plant())
                            planted = true;
                    }
                }
            }
        }
    }
}
