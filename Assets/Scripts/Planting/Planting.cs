using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames;

public class Planting : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerHoldingPoint;
    [SerializeField] private LayerMask seedLayerMask;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private float interactDistance;

    private GameObject isHolding;

    private void Start()
    {
        isHolding = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(playerTransform.position + new Vector3(0, 0.1f, 0), playerTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
                {
                    isHolding = showPlant.Interact(isHolding);
                }
            }

            if (Physics.Raycast(playerTransform.position + new Vector3(0, 0.1f, 0), playerTransform.forward, out RaycastHit raycastHitSeed, interactDistance, seedLayerMask))
            {
                Debug.Log(raycastHitSeed.transform.gameObject);

                if (!isHolding)
                {
                    isHolding = raycastHitSeed.transform.gameObject.GetComponent<SeedsManager>().GetSeed(raycastHitSeed.transform.gameObject, playerHoldingPoint);
                }
            }
            
        }
    }
}
