using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector : MonoBehaviour
{
   [Header("Ref")]
   [SerializeFiled] private Transform ItemHolder;
   private int numOfItemHolding = 0;
   [ ]
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddItem(Transform itemToAdd)
    {
        numOfItemHolding++;
        itemToAdd.SetParent(ItemHolder,true);
        itemToAdd.localPosition = Vector3.zero
    }
    
}
