using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Player playerInput;
   private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;


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
 
    void Update()
    {
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
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
