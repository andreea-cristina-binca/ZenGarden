using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamViewChanger : MonoBehaviour
{
    public Camera firstPerson;
    public Camera thirdPerson;
    public GameObject crosshair;

    public bool isFirst;

    void Start()
    {
        SetToFirstPerson();
        isFirst = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isFirst)
            {
                SetToThirdPerson();
                isFirst = false;
            }
            else
            {
                SetToFirstPerson();
                isFirst = true;
            }
        }
    }

    private void SetToFirstPerson()
    {
        firstPerson.enabled = true;
        firstPerson.GetComponent<MouseLook>().enabled = true;

        thirdPerson.enabled = false;
        thirdPerson.GetComponent<MouseOrbit>().enabled = false;
        thirdPerson.GetComponent<MouseLook>().enabled = false;

        crosshair.GetComponent<Image>().enabled = true;
    }

    private void SetToThirdPerson()
    {
        firstPerson.enabled = false;
        firstPerson.GetComponent<MouseLook>().enabled = false;

        thirdPerson.enabled = true;
        thirdPerson.GetComponent<MouseOrbit>().enabled = true;
        thirdPerson.GetComponent<MouseLook>().enabled = true;

        crosshair.GetComponent<Image>().enabled = false;
    }
}
