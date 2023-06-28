using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Vendor"))
        {
            doorAnimator.SetBool("isOpen", true);
            Debug.Log("entered");
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Vendor"))
            Debug.Log(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Vendor"))
        {
            doorAnimator.SetBool("isOpen", false);
        }
            Debug.Log("exited");
    }
}
