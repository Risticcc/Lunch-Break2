using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl: MonoBehaviour
{
   bool isAlredyCollected = false;

   
   private  void OnTriggerEnter(Collider other)
   {
        
        if(isAlredyCollected)
            return;

       if(other.CompareTag("Player"))
        {
            BoxCollector boxCollector;
            if(other.TryGetComponent(out boxCollector))
            {
                isAlredyCollected = boxCollector.AddItem(this.transform);
            }
        }
  }
   
}
