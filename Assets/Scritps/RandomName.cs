using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;

public class RandomName : MonoBehaviour
{
 private string[] names = {"Akibrus", "Angun" ,"Balrus","Bulruk" ,"Caldor", "Dagen", "Darvyn" ,"Delvin" ,"Dracyian","Dray" };

 private void Awake()
 {
  this.gameObject.name = names[UnityEngine.Random.Range(0, names.Length)];
 }
}
