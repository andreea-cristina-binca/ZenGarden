using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamViewChanger : MonoBehaviour
{
    [SerializeField] private Camera firstPerson;
    [SerializeField] private Camera thirdPerson;

    private bool isFirst;

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
        thirdPerson.enabled = false;
    }

    private void SetToThirdPerson()
    {
        firstPerson.enabled = false;
        thirdPerson.enabled = true;
    }
}
