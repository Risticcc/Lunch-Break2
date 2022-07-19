using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnergyBar : MonoBehaviour
{
    [SerializeField] private GameObject bar;
    [SerializeField] int time;
    private bool filling = false;

    // Start is called before the first frame update
    void Start()
    {
        if(!filling)
            EmptyBar();
       
    }

   
    public void EmptyBar()
    {
        LeanTween.scaleX(bar,0,time);
    }

    public void Fill(float amount)
    {
        filling = true;
        LeanTween.scaleX(bar,amount,time);
        filling = false;
    }
}
