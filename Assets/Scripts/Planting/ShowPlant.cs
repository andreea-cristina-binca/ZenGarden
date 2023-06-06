using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowPlant : MonoBehaviour
{
    [SerializeField] private PlantSO plantObject;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject timerObject;
    [SerializeField] private PlantSO plantStartObject;

    private Transform plantTransform;
    private TimerManager timer;
    private bool planted;

    private void Start()
    {
        timer = timerObject.GetComponent<TimerManager>();
        timer.SetSeconds(plantObject.seconds);
        timer.SetMinutes(plantObject.minutes);
        timer.SetHours(plantObject.hours);

        timerObject.SetActive(false);
        planted = false;
    }

    private void Update()
    {
        if (planted)
        {
            if (timer.GetHoursLeft() == 0 && timer.GetMinutesLeft() == 0 && timer.GetSecondsLeft() == 0)
            {
                Destroy(plantTransform.gameObject);

                plantTransform = Instantiate(plantObject.prefab, spawnPoint);
                plantTransform.localPosition = Vector3.zero;

                planted = false;
            }
        }

        if (plantTransform == null)
        {
            timerObject.SetActive(false);
        }
    }

    public bool Plant()
    {
        if (planted == false)
        {
            plantTransform = Instantiate(plantStartObject.prefab, spawnPoint);
            plantTransform.localPosition = Vector3.zero;

            timerObject.SetActive(true);
            planted = true;

            return true;
        }

        return false;
    }

    public bool Harvest()
    {
        if (timer.GetHoursLeft() == 0 && timer.GetMinutesLeft() == 0 && timer.GetSecondsLeft() == 0)
        {
            timerObject.SetActive(false);
            planted = false;
            
            return true;
        }

        return false;
    }
}
