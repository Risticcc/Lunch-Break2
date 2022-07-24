using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Lunch Break2/Item", order = 0)]
public class Item : ScriptableObject 
{
    public string itemName;
    public int price;
    public float boost;
}

