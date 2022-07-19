using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollector: MonoBehaviour
{
   [Header("Ref")]
   [SerializeField] private Transform ItemHolder;
   private PlayerController playerController;
   private int numOfItemHolding = 0;
   private int _strength;

    public int NumOfItemHolding { get => numOfItemHolding; set => numOfItemHolding = value; }


    void Start()
    {
        playerController = GetComponent<PlayerController>();
        IncreaseStrength();
        playerController.onBoost += IncreaseStrength;
    }


    public void AddItem(Transform itemToAdd)
    {   
        if(numOfItemHolding >= _strength)
        {
            //animacija neka
        }
        else
        {
            itemToAdd.DOMove(ItemHolder.transform.position,0.1f).OnComplete(
            ()=>{
                NumOfItemHolding++;
                itemToAdd.SetParent(ItemHolder,true);
                itemToAdd.localPosition = new Vector3(0, (float)0.25 * NumOfItemHolding,0);
                itemToAdd.localRotation = Quaternion.identity;
            }
            );
        }

        //set up moving animation
        playerController.CurrentAnimation = AnimationNames.Carry.ToString();
        playerController.InactiveAnimation = AnimationNames.Run.ToString();
    }

    
    public void RemoveItems(GameObject player)
    {
        foreach(Transform box in player.transform.GetChild(2))
        {
            Debug.Log("e");
            if(box.gameObject.tag == "CollectItem")
            {
                Destroy(box.gameObject);
                AddPoints();
            }
        }
        numOfItemHolding = 0;

        //set up moving animation
        playerController.CurrentAnimation = AnimationNames.Run.ToString();
        playerController.InactiveAnimation = AnimationNames.Carry.ToString();
    }


    //Add money
    private void AddPoints()
    {
        ScoreManager.Instance.AddScore();
        //neki partikli
        //vibracija
    }

    private void IncreaseStrength()
    {
        _strength = playerController.Strength;
    }
}
