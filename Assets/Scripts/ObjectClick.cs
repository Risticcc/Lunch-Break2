using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectClick : MonoBehaviour

{
    private Animator animator;
    

    [SerializeField]
    private InputAction mouseClick;
    private Camera mainCamera;
    private BasketAnim basketAnim;

    private ClickEvent sa;

    private void Awake()
    {
        sa = new ClickEvent();
;
    }

    private void OnEnable()
    {
        sa.Player.Select.started += Clicked;
        sa.Player.Select.canceled += Relesed;
        sa.Player.Enable();
    }

 

    private void OnDisable()
    {
        sa.Player.Select.started -= Clicked;
        sa.Player.Select.canceled -= Relesed;
        sa.Player.Enable();
    }
    void Start()
    {
       this.mainCamera = Camera.main;
        animator = GetComponent<Animator>();

        basketAnim = GameObject.FindGameObjectWithTag("Basket").GetComponent<BasketAnim>();
            

    }

    // Update is called once per frame

    private void Relesed(InputAction.CallbackContext obj)
    {
       
    }

    private void Clicked(InputAction.CallbackContext obj)
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        RaycastHit hit;
        Ray ray = this.mainCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (gameObject.tag == "Door")
            {
                if (animator)
                    animator.SetTrigger("OnClick");
               StartCoroutine( basketAnim.DelayAnim());               

            }
        }
                // StartCoroutine(DelayAnim(animator.GetCurrentAnimatorStateInfo(0).length));


            }
        
    }

   
 

  
   
  

