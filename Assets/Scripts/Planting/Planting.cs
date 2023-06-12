using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames;

public class Planting : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerHoldingPoint;
    [SerializeField] private LayerMask seedLayerMask;
    [SerializeField] private LayerMask interactLayerMask;
    [SerializeField] private float interactDistance;

    private GameObject isHolding;
    private bool plantedSquating;
    private bool plantedStanding;
    private bool pickedUpSeeds;

    private void Start()
    {
        isHolding = null;

        plantedSquating = false;
        pickedUpSeeds = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(playerTransform.position + new Vector3(0, 0.1f, 0), playerTransform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ShowPlant showPlant))
                {
                    GameObject wasHolding = isHolding;
                    isHolding = showPlant.Interact(isHolding);
                    Debug.Log(isHolding);

                    if(wasHolding != null && isHolding == null)
                    {
                        if (raycastHit.transform.gameObject.tag == "PlantStand")
                            plantedStanding = true;
                        else
                            plantedSquating = true;
                    }
                }
            }

            if (Physics.Raycast(playerTransform.position + new Vector3(0, 0.1f, 0), playerTransform.forward, out RaycastHit raycastHitSeed, interactDistance, seedLayerMask))
            {
                Debug.Log(raycastHitSeed.transform.gameObject);

                if (!isHolding)
                {
                    isHolding = raycastHitSeed.transform.gameObject.GetComponent<SeedsManager>().GetSeed(raycastHitSeed.transform.gameObject, playerHoldingPoint);

                    if (isHolding != null)
                    {
                        pickedUpSeeds = true;
                    }
                }
            }
        }
        
        //Debug.Log(plantedSquating);
        //Debug.Log(pickedUpSeeds);
        if (plantedSquating || plantedStanding || pickedUpSeeds)
        {
            if (plantedStanding)
                animator.SetBool("isIntStanding", true);
            else
                animator.SetBool("isIntSquating", true);

            //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                //Debug.Log("done squat animation");
                if (plantedSquating)
                    plantedSquating = false;
                if (plantedStanding)
                    plantedStanding = false;
                if (pickedUpSeeds)
                    pickedUpSeeds = false;
            }
        }
        else
        {
            animator.SetBool("isIntStanding", false);
            animator.SetBool("isIntSquating", false);
        }
    }
}
