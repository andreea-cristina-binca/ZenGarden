using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudColor : MonoBehaviour
{
    [SerializeField] private GameObject day;
    [SerializeField] private GameObject dawnDusk;
    [SerializeField] private GameObject night;

    private int timeOfDay;

    private void Start()
    {
        timeOfDay = -1;
    }

    private void Update()
    {
        if (timeOfDay != 0 && (Clock.ClockHour >= 5 && Clock.ClockHour < 7))
        {
            day.SetActive(false);
            night.SetActive(false);
            dawnDusk.SetActive(true);
        }
        else if (timeOfDay != 1 && (Clock.ClockHour >= 7 && Clock.ClockHour < 17))
        {
            day.SetActive(true);
            night.SetActive(false);
            dawnDusk.SetActive(false);
        }
        else if (timeOfDay != 2 && (Clock.ClockHour >= 17 && Clock.ClockHour < 19))
        {
            day.SetActive(false);
            night.SetActive(false);
            dawnDusk.SetActive(true);
        }
        else if (timeOfDay != 3 && (Clock.ClockHour >= 19 || Clock.ClockHour < 5))
        {
            day.SetActive(false);
            night.SetActive(true);
            dawnDusk.SetActive(false);
        }
    }
}
