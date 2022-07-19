using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Renderer renderer;
    private Animator animator;


    void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        //renderer.material.color = Color.red;
        animator.SetTrigger("OnClick");
    }

    private void OnMouseExit()
    {
       // renderer.material.color = Color.white;
    }


}
