using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadPlayer : MonoBehaviour
{
    private BoxCollector boxController;
    private Animator animator;
    void Start()
    {
        boxController  = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollector>();
        animator = GetComponent<Animator>();

        animator.SetTrigger("start");
    }


    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player"))
            boxController.RemoveItems(other.gameObject);
    }
    
    
}
