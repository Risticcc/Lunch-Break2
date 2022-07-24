using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadPlayer : MonoBehaviour
{
    private BoxCollector boxController;
    void Start()
    {
        boxController  = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollector>();

    }


    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player"))
            boxController.RemoveItems(other.gameObject);
    }
    
    
}
