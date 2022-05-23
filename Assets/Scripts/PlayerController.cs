using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody2D rb;



    private void Awake() {
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
    }
}
