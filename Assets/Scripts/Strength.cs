using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Strength", menuName = "Lunch Break2/Strength", order = 0)]
public class Strength : ScriptableObject 
{
    public int amount;

    [System.NonSerialized]
    public UnityEvent<int> strengthChanged;

    private  void OnEnable() {
       amount = 3;
        if(strengthChanged == null)
            strengthChanged = new UnityEvent<int>();
    }

    public void Boost(int amount)
    {
        this.amount += amount;
        strengthChanged?.Invoke(this.amount);
    }
}
