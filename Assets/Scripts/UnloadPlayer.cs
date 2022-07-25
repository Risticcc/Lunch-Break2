using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnloadPlayer : MonoBehaviour
{
    private BoxCollector boxController;
    Transform sceneTextAnim;
    [SerializeField]  TextMeshProUGUI text;
    [SerializeField] Animator animator;
    void Start()
    {
        boxController  = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollector>();
        
       SetUpText();
    }


    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Player"))
            boxController.RemoveItems(other.gameObject);
    }

    private void SetUpText()
    {
           
            
            Debug.Log(text);

            text.text = "DROP HERE";
            animator.SetTrigger("start");

    }
    
    
}
