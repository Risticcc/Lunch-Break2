using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Rigidbody _rb;

 
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void FixedUpdate()
    {
       _rb.velocity = new Vector3(_joystick.Horizontal * _speed, _rb.velocity.y, _joystick.Vertical * _speed);

      
      
        if (_joystick.Vertical != 0 || _joystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        Debug.Log("e");
    }
}