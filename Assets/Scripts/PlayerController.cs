using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private float movementSpeed = 5f;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;



    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.velocity = input.MovementVector * movementSpeed * Time.fixedDeltaTime;

        if(input.MovementVector.x > 0)
        {
            print("facing right");
        }
        else if(input.MovementVector.x < 0)
        {
            print("facing left");
        }

        //transform.Translate(input.MovementVector * movementSpeed * Time.deltaTime);        
    }
}
