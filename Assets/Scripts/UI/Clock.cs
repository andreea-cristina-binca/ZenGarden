using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public static int ClockHour;
    public static int ClockMinute;

    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI date;

    private int minutes;
    private int hours;
    private int day;
    private int month;
    private int year;

    private int oldMinutes;
    private int oldHours;

    private void Start()
    {
        UpdateTime();
        UpdateDate();

        oldMinutes = minutes;
        oldHours = hours;

        ClockMinute = minutes;
        ClockHour = hours;
    }

    private void Update()
    {
        int checkMinutes = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("mm"));

        if (checkMinutes != oldMinutes)
        {
            UpdateTime();
            oldMinutes = minutes;
            ClockMinute = minutes;

            if (oldHours != hours)
            {
                UpdateDate();
                oldHours = hours;
                ClockHour = hours;
            }
        }
    }

    private void UpdateTime()
    {
        minutes = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("mm"));
        hours = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));

        string tod = System.DateTime.UtcNow.ToLocalTime().ToString("tt");
        if (tod.ToLower().Equals("p.m."))
            hours += 12;

        time.text = $"{hours:00}:{minutes:00}";
    }

    private void UpdateDate()
    {
        day = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("dd"));
        month = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("MM"));
        year = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("yyyy"));

        date.text = $"{day:00}-{month:00}-{year:00}";
    }
}
