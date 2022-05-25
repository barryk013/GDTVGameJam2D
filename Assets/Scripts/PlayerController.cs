using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
    }
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        input.EnableControls(true);
    }
    private void OnDisable()
    {
        input.EnableControls(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rigidBody.velocity = movementSpeed * Time.fixedDeltaTime * input.MovementVector;
    }
}
