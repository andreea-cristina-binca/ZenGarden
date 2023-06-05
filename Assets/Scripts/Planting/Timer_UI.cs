using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer_UI : MonoBehaviour
{
    [SerializeField] private TextMeshPro timeText;
    [SerializeField] private TimerManager timer;

    private void OnEnable()
    {
        TimerManager.OnSecondChanged += UpdateTime;
        TimerManager.OnMinuteChanged += UpdateTime;
        TimerManager.OnHourChanged += UpdateTime;

        timeText.text = "Planting...";
    }

    private void OnDisable()
    {
        TimerManager.OnSecondChanged -= UpdateTime;
        TimerManager.OnMinuteChanged -= UpdateTime;
        TimerManager.OnHourChanged -= UpdateTime;
    }

    public TextMeshPro getTimeText()
    {
        return timeText;
    }

    private void UpdateTime()
    {
        if (timer.GetHoursLeft() != 0 || timer.GetMinutesLeft() != 0 || timer.GetSecondsLeft() != 0)
        {
            timeText.text = $"{timer.GetHoursLeft():00}:{timer.GetMinutesLeft():00}:{timer.GetSecondsLeft():00}";
        }
        else
        {
            timeText.text = "Done!";
        }
    }
}
