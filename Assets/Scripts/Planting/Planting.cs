using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevionGames;

public class Planting : MonoBehaviour
{
    public Animator animator;
    public AudioClip planting;
    public AudioClip pickingUp;

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

                    if(wasHolding != null && isHolding == null)
                    {
                        if (raycastHit.transform.gameObject.tag == "PlantStand")
                            plantedStanding = true;
                        else
                            plantedSquating = true;

                        AudioSource.PlayClipAtPoint(planting, transform.position, 0.5f);
                    }
                }
            }

            if (Physics.Raycast(playerTransform.position + new Vector3(0, 0.1f, 0), playerTransform.forward, out RaycastHit raycastHitSeed, interactDistance, seedLayerMask))
            {
                if (!isHolding)
                {
                    isHolding = raycastHitSeed.transform.gameObject.GetComponent<SeedsManager>().GetSeed(raycastHitSeed.transform.gameObject, playerHoldingPoint);

                    if (isHolding != null)
                    {
                        pickedUpSeeds = true;

                        AudioSource.PlayClipAtPoint(pickingUp, transform.position, 0.5f);
                    }
                }
            }
        }
        
        if (plantedSquating || plantedStanding || pickedUpSeeds)
        {
            if (plantedStanding)
                animator.SetBool("isIntStanding", true);
            else
                animator.SetBool("isIntSquating", true);
            
            gameObject.GetComponent<Player>().enabled = false;

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                if (plantedSquating)
                    plantedSquating = false;
                if (plantedStanding)
                    plantedStanding = false;
                if (pickedUpSeeds)
                    pickedUpSeeds = false;

                gameObject.GetComponent<Player>().enabled = true;
            }
        }
        else
        {
            animator.SetBool("isIntStanding", false);
            animator.SetBool("isIntSquating", false);
        }
    }
}
