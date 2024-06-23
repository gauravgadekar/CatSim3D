using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockBonusItems : MonoBehaviour
{
    public int daysPlayed;
    public Button skin2Btn;
    private void Start()
    {
        daysPlayed= PlayerPrefs.GetInt("DaysPlayed");

        if (daysPlayed>=0)
        {
            PlayerPrefs.SetInt("Skin2_Unlocked",1);
            skin2Btn.interactable = true;
        }
    }
}
