using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;

    Vector2 move;

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
        Vector2 move = playerInput.actions["Move"].ReadValue<Vector2>();
        float playerSpeed = 5f * Time.deltaTime;

        transform.Translate(move * playerSpeed);
        
    }
}
