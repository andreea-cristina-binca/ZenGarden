using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private CamViewChanger camView;

    private void OnEnable()
    {
        if (camView.isFirst)
        {
            camView.firstPerson.GetComponent<MouseLook>().enabled = true;
        }
        else
        {
            camView.thirdPerson.GetComponent<MouseLook>().enabled = true;
            camView.thirdPerson.GetComponent<MouseOrbit>().enabled = true;
        }
    }

    private void OnDisable()
    {
        if (camView.isFirst)
        {
            camView.firstPerson.GetComponent<MouseLook>().enabled = false;
        }
        else
        {
            camView.thirdPerson.GetComponent<MouseLook>().enabled = false;
            camView.thirdPerson.GetComponent<MouseOrbit>().enabled = false;
        }
    }
}
