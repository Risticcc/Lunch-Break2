using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector: MonoBehaviour
{
    [SerializeField] private Transform ItemHolder;
    [SerializeField] private int numOfItemHolding = 0; //how many boxes player is carring
    private PlayerController playerController;
    private int boxPrice = 1; //make this scriptableobject

    public int NumOfItemHolding { get => numOfItemHolding; set => numOfItemHolding = value; }


    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    
    public bool AddItem(Transform itemToAdd)
    {   
       if(numOfItemHolding >= playerController.Strength.amount)
        return false;
       
        itemToAdd.DOMove(ItemHolder.transform.position,0.1f).OnComplete(
        ()=>{
            NumOfItemHolding++;
            itemToAdd.SetParent(ItemHolder,true);
            itemToAdd.localPosition = new Vector3(0, (float)0.25 * NumOfItemHolding,0);
            itemToAdd.localRotation = Quaternion.identity;
        }
        );
        
        //set up moving animation
         AnimationController(AnimationNames.Carry.ToString(),AnimationNames.Run.ToString());

         return true;
    }

    
    public void RemoveItems(GameObject player)
    {
        foreach(Transform box in player.transform.GetChild(2))
        {
            if(box.gameObject.tag == "CollectItem")
            {
                Destroy(box.gameObject);
                AddPoints();
            }
        }
        numOfItemHolding = 0;

        //set up moving animation
        AnimationController(AnimationNames.Run.ToString(), AnimationNames.Carry.ToString());
    }


    //set up active and inactive animations
    private void AnimationController(string active, string inactive)
    {
        playerController.CurrentAnimation = active;
        playerController.InactiveAnimation = inactive;
    }


    //Add money
    private void AddPoints()
    {
        ScoreManager.Instance.AddScore(boxPrice);
        //neki partikli
        //vibracija
    }
}
