using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendorController : MonoBehaviour
{
    [SerializeField] private Animator vendorAnimator;
    [SerializeField] private Button callButton;

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform turnPoint;

    private bool hasBeenCalled;
    private bool hasLeft;
    private float interpolateAmount;


    void Start()
    {
        vendorAnimator.SetBool("isWalking", false);
        hasBeenCalled = false;

        transform.position = startPoint.position;
        interpolateAmount = 0;
    }

    private void Awake()
    {
        callButton.onClick.AddListener(() =>
        {
            vendorAnimator.SetBool("isWalking", true);
            hasBeenCalled = true;
        });
    }

    void Update()
    {
        if (hasBeenCalled)
        {
            interpolateAmount = (interpolateAmount + Time.deltaTime * 0.1f);

            Vector3 firstPart = Vector3.Lerp(startPoint.position, turnPoint.position, interpolateAmount);
            Vector3 secondPart = Vector3.Lerp(turnPoint.position, endPoint.position, interpolateAmount);
            transform.position = Vector3.Lerp(firstPart, secondPart, interpolateAmount);

            if (transform.position == endPoint.position)
            {
                vendorAnimator.SetBool("isWalking", false);
                hasBeenCalled = false;

                interpolateAmount = 0;
            }
        }

        if (hasLeft)
        {
            interpolateAmount = (interpolateAmount + Time.deltaTime * 0.1f);

            Vector3 firstPart = Vector3.Lerp(endPoint.position, turnPoint.position, interpolateAmount);
            Vector3 secondPart = Vector3.Lerp(turnPoint.position, startPoint.position, interpolateAmount);
            transform.position = Vector3.Lerp(firstPart, secondPart, interpolateAmount);

            if (transform.position == startPoint.position)
            {
                vendorAnimator.SetBool("isWalking", false);
                hasLeft = false;

                interpolateAmount = 0;

                var lookDir = endPoint.position - transform.position;
                lookDir.y = 0;
                transform.rotation = Quaternion.LookRotation(lookDir);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            vendorAnimator.SetBool("isWalking", true);
            hasLeft = true;

            var lookDir = startPoint.position - transform.position;
            lookDir.y = 0;
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
