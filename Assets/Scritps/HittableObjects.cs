using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableObjects : MonoBehaviour
{
    public int points = 50;
    public int coins;


    private void Awake()
    {
        coins = PlayerPrefs.GetInt("coinsLevel", 1);
    }
}
