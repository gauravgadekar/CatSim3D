using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject shop;
    public CatSkin cs;
    
    public void SelectSkin(int skinId)
    {
        print("skin selected" + skinId);
        PlayerPrefs.SetInt("SelectSkin",skinId);
        cs.SetSkin(skinId);
        shop.SetActive(false);
    }
}
