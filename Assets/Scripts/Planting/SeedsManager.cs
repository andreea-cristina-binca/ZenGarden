using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames.InventorySystem;

public class SeedsManager : MonoBehaviour
{
    [SerializeField] private GameObject tulipSeed;
    [SerializeField] private GameObject roseSeed;
    [SerializeField] private GameObject daffodilSeed;
    [SerializeField] private GameObject yellowCoreSeed;
    [SerializeField] private GameObject lillySeed;
    [SerializeField] private GameObject sunflowerSeed;
    [SerializeField] private GameObject snowdropSeed;
    [SerializeField] private GameObject poinsettiaSeed;

    private Transform holdingTransform;

    public GameObject GetSeed(GameObject seedGameObject, Transform playerHoldingPoint)
    {
        gameObject.GetComponent<ItemCollection>().RemoveAt(0);
        if (gameObject.GetComponent<ItemCollection>().IsEmpty)
            Destroy(gameObject);

        switch (seedGameObject.tag)
        {
            case "Tulip":
                holdingTransform = Instantiate(tulipSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "Rose":
                holdingTransform = Instantiate(roseSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "Daffodil":
                holdingTransform = GameObject.Instantiate(daffodilSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "YellowCore":
                holdingTransform = GameObject.Instantiate(yellowCoreSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "Lilly":
                holdingTransform = GameObject.Instantiate(lillySeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "Sunflower":
                holdingTransform = GameObject.Instantiate(sunflowerSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "Snowdrop":
                holdingTransform = GameObject.Instantiate(snowdropSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            case "Poinsettia":
                holdingTransform = GameObject.Instantiate(poinsettiaSeed.transform, playerHoldingPoint);
                holdingTransform.localPosition = Vector3.zero;
                break;
            default:
                break;
        }
        
        return holdingTransform.gameObject;
    }
}
