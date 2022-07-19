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
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Rigidbody _rb;
    private string _currentAnimation;
    private string _inactiveAnimation;
    private Animator animator;

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

    public void FixedUpdate()
    {
        #region: Player movement
       _rb.velocity = new Vector3(_joystick.Horizontal * _speed, _rb.velocity.y, _joystick.Vertical * _speed);

        //controling  moving animation and rotation 
        if (_joystick.Vertical != 0 || _joystick.Horizontal != 0) 
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
      
            animator.SetBool(CurrentAnimation, true); 
            animator.SetBool(InactiveAnimation,false);  
        }
        else
        {
            animator.SetBool(AnimationNames.Run.ToString(),false);
            animator.SetBool(AnimationNames.Carry.ToString() ,false);
        }
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