using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUi : MonoBehaviour
{
    public TextMeshProUGUI nbCoinstext;

    private int initialPrice = 10;
    private int coinsLevel;
    private int coinsActualprice;
    public TextMeshProUGUI coinsPriceText;
    public TextMeshProUGUI coinsLevelText;

    public int playerNbcoins;
    private void Awake()
    {
        playerNbcoins = PlayerPrefs.GetInt("nbCoins", 0);
        nbCoinstext.text = playerNbcoins.ToString();
        coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
        coinsActualprice = initialPrice * coinsLevel;
        coinsPriceText.text = coinsActualprice + "PO";
        coinsLevelText.text = "LEVEL" + coinsLevel;
    }

    public void IncrementCoinLevel()
    {
        if (playerNbcoins >= coinsActualprice)
        {
            playerNbcoins -= coinsActualprice;
            PlayerPrefs.SetInt("nbCoins", playerNbcoins);
            nbCoinstext.text = playerNbcoins.ToString();
            PlayerPrefs.SetInt("coinsLevel",PlayerPrefs.GetInt("coinsLevel", 1) + 1);
            coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
            coinsLevelText.text = "LEVEL" + coinsLevel;
            coinsActualprice = initialPrice * coinsLevel;
            coinsPriceText.text = coinsActualprice + "PO";
        }
    }
}
