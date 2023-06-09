using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.InputSystem.XR.TrackedPoseDriver;


public class TimerManager : MonoBehaviour
{
    public static Action OnSecondChanged;
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    private int Second;
    private int Minute;
    private int Hour;

    private int timerSeconds;
    private int timerMinutes;
    private int timerHours;

    private float secondsToRealTime = 1.0f;
    private float passedSeconds;

    void Start()
    {
        Second = timerSeconds;
        Minute = timerMinutes;
        Hour = timerHours;

        passedSeconds = secondsToRealTime;
    }

    void Update()
    {
        if (Second != 0 || Minute != 0 || Hour != 0)
        {
            passedSeconds -= Time.deltaTime;

            if (passedSeconds <= 0)
            {
                Second--;
                OnSecondChanged?.Invoke();

                if (Second < 0)
                {
                    Second = 59;
                    Minute--;
                    OnMinuteChanged?.Invoke();

                    if (Minute < 0)
                    {
                        Minute = 59;
                        Hour--;
                        OnHourChanged?.Invoke();
                    }
                }

                passedSeconds = secondsToRealTime;
            }
        }
    }

    private void OnEnable()
    {
        Second = timerSeconds;
        Minute = timerMinutes;
        Hour = timerHours;

        passedSeconds = secondsToRealTime;
    }

    private void OnDisable()
    {
    }

    public int GetSecondsLeft()
    {
        return Second;
    }

    public int GetMinutesLeft()
    {
        return Minute;
    }

    public int GetHoursLeft()
    {
        return Hour;
    }

    public void SetSeconds(int seconds)
    {
        timerSeconds = seconds;
    }

    public void SetMinutes(int minutes)
    {
        timerMinutes = minutes;
    }

    public void SetHours(int hours)
    {
        timerHours = hours;
    }
}
