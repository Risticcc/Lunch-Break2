using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationNames{
    Run,
    Carry
}

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
   
    [Header("Settings")]
    [SerializeField] private float _speed;

    //[SerializeField] private int _strength = 3;
    [SerializeField] private Strength _strength;
   // [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Rigidbody _rb;
    private string _currentAnimation;
    private string _inactiveAnimation;
    private Animator animator;

    private Player playerInput;
   private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;


    public string CurrentAnimation { get => _currentAnimation; set => _currentAnimation = value; }
    public string InactiveAnimation { get => _inactiveAnimation; set => _inactiveAnimation = value; }
    public Strength Strength { get => _strength; set => _strength = value; }

    void Start()
    {
        animator = GetComponent<Animator>();
        //boxCollector = GetComponent<BoxCollector>();
        
        //set initial animation
        CurrentAnimation = AnimationNames.Run.ToString();
        InactiveAnimation = AnimationNames.Carry.ToString();
        
    }

    void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
    }
    void OnEnable()
    {
        playerInput.Enable();
    }


    void OnDisable()
    {
        playerInput.Disable();
    }

   // public void FixedUpdate()
    //{
      //  #region: Player movement
    //    _rb.velocity = new Vector3(_joystick.Horizontal * _speed, _rb.velocity.y, _joystick.Vertical * _speed);

    //     //controling  moving animation and rotation 
    //     if (_joystick.Vertical != 0 || _joystick.Horizontal != 0) 
    //     {
    //         transform.rotation = Quaternion.LookRotation(_rb.velocity);
      
    //         animator.SetBool(CurrentAnimation, true); 
    //         animator.SetBool(InactiveAnimation,false);  
    //     }
    //     else
    //     {
    //         animator.SetBool(AnimationNames.Run.ToString(),false);
    //         animator.SetBool(AnimationNames.Carry.ToString() ,false);
    //     }
       // #endregion 
    //}
     void Update()
    {
        #region Player Movement
        if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movmentInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movmentInput.x,0,movmentInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;

            animator.SetBool(CurrentAnimation, true); 
            animator.SetBool(InactiveAnimation,false);  
        }
        else
        {
            animator.SetBool(AnimationNames.Run.ToString(),false);
            animator.SetBool(AnimationNames.Carry.ToString() ,false);
        }

        controller.Move(playerVelocity * Time.deltaTime);
        #endregion
    }

    public void SpeedUpMovement(int accelarateRate)
    {
         _speed += accelarateRate;
        animator.speed += accelarateRate;
    }

    public void SlowDownMovement(int decelarateRate)
    {
            _speed -= decelarateRate;
            animator.speed -= decelarateRate;
    }

    public void IncreaseStrength(int amount)
    {
        //how many boxes player can carry
        _strength.Boost(amount);
    }
    

  
}