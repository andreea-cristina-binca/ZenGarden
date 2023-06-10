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
            if (Physics.Raycast(playerTransform.position + new Vector3(0, 0.1f, 0), playerTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            {
                //Debug.Log(playerTransform.position);
                //Debug.Log(raycastHit.transform.TryGetComponent(out ShowPlant showPlant));
                //if(showPlant)
                if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
                {
                    showPlant.Interact();
                }
            }

            //if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            //{
            //    // Debug.Log(raycastHit.transform);
            //    if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
            //    {
            //        if (planted)
            //        {
            //            if (showPlant.Harvest())
            //                planted = false;
            //        }
            //        else
            //        {
            //            if (showPlant.Plant())
            //                planted = true;
            //        }
            //    }
            //}
        }
    }
}
