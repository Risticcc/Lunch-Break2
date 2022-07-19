using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketAnim : MonoBehaviour
{
    private Animator animator2;


    void Start()
    {
        animator2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator  DelayAnim(float _delay = 1)
    {
        yield return new WaitForSeconds(_delay);
        animator2.SetTrigger("IsOpened");

    }
}
