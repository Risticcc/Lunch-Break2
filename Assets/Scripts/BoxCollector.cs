using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxCollector: MonoBehaviour
{
    [SerializeField]  TextMeshProUGUI text;
    [SerializeField] Animator animator;
    [SerializeField] private Transform ItemHolder;
    private PlayerController playerController;
    private int numOfItemHolding = 0; //amount of boxes player is carring
    private List<Transform> holdedItems; //currently holded items
    private int boxPrice = 1; //amount money you will get

    public int NumOfItemHolding { get => numOfItemHolding; set => numOfItemHolding = value; }


    void Start()
    {
        playerController = GetComponent<PlayerController>();
        holdedItems = new List<Transform>();

    }

    
    public bool AddItem(Transform itemToAdd)
    {   
       if(numOfItemHolding >= playerController.Strength.amount)
        return false;
       
        itemToAdd.DOMove(ItemHolder.transform.position,0.1f).OnComplete(
        ()=>{
            NumOfItemHolding++;
            itemToAdd.SetParent(ItemHolder,true);
            itemToAdd.localPosition = new Vector3(0, (float)0.4 * NumOfItemHolding,0);
            itemToAdd.localRotation = Quaternion.identity;
        }
        );
        holdedItems.Add(itemToAdd);
        
        //set up moving animation
         AnimationController(AnimationNames.Carry.ToString(),AnimationNames.Run.ToString());

         return true;
    }

    
    public void RemoveItems(GameObject player, Color color)
    {
        
        //foreach(Transform box in player.transform.GetChild(2))
        
        for(int i = ItemHolder.childCount-1; i >= 0; i--)
        {
            if(ItemHolder.GetChild(i).gameObject.tag != "CollectItem")
                return;

            //check color of the boxes
            if(!ColorCheck(ItemHolder.GetChild(i),color))
            {
                Debug.Log("razlicite boje");
                animator.SetTrigger("start");
                return;
            }
            
            if( holdedItems[holdedItems.Count-1].Equals(ItemHolder.GetChild(i)))
            {
                Destroy(ItemHolder.GetChild(i).gameObject);
                holdedItems.Remove(ItemHolder.GetChild(i));
                numOfItemHolding --;
                AddPoints();
            }
            Debug.Log("AAA");
        }

        //set up moving animation
        AnimationController(AnimationNames.Run.ToString(), AnimationNames.Carry.ToString());
    }


    private bool ColorCheck(Transform box, Color containerColor)
    {  
        Color boxColor;
        boxColor = box.GetChild(0).GetChild(1).GetComponent<Renderer>().material.color;
        Debug.Log($"Container color {containerColor} , box color{boxColor}");
        return boxColor.Equals(containerColor);
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
