using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedSkin : MonoBehaviour
{
    public Button btnToUnlock;
    public string prefsKey;
    private void Start()
    {
        if (PlayerPrefs.GetInt(prefsKey,0)==1)
        {
            btnToUnlock.interactable = true;
        }
    }
}
