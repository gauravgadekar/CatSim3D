using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysSinceLastLaunch : MonoBehaviour
{
    private System.DateTime startDate;
    private System.DateTime today;

    private void Awake()
    {
        setStartDate();
    }

    void setStartDate()
    {
        if (PlayerPrefs.HasKey("StartDate"))
        {
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
        }
        else
        {
            startDate = System.DateTime.Now;
            PlayerPrefs.SetString("StartDate", startDate.ToString());
        }
        
        PlayerPrefs.SetInt("DaysPlayed", GetDaysPlayed());
    }

    int GetDaysPlayed()
    {
        today = System.DateTime.Now;
        System.TimeSpan elapsed = today.Subtract(startDate);
        double days = elapsed.TotalDays;
        return int.Parse(days.ToString("0"));
    }
}
