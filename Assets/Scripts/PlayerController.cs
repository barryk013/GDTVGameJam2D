using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;
    [SerializeField] private float movementSpeed = 5f;
    private Rigidbody2D _rigidBody;
    private Animator _animator;

    private Vector3 refVel = Vector3.zero;

    [SerializeField] private Vector3 initialPos;
    private Vector3 startingPos;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        
    }
    
    private void OnEnable()
    {
        startingPos = GameObject.FindGameObjectWithTag("StartingPosition").transform.position;
        transform.position = initialPos;        
        input.MovementPerformed += OnMovementPerformed;
        input.MovementCanceled += OnMovementCanceled;
    }
    private void OnDisable()
    {
        input.EnableControls(false);
        input.MovementPerformed -= OnMovementPerformed;
        input.MovementCanceled -= OnMovementCanceled;
    }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(MoveToInitialPosition());
    }

    private void OnMovementPerformed()
    {
        _animator.SetBool("Moving", true);
    }
    private void OnMovementCanceled()
    {
        _animator.SetBool("Moving", false);
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

    IEnumerator MoveToInitialPosition()
    {
        OnMovementPerformed();
        input.EnableControls(false);

        float lerpTime = 5f;
        float timer = 0;

        while (timer < lerpTime)
        {
            transform.position = Vector3.Lerp(initialPos, startingPos, timer/lerpTime);
            timer += Time.deltaTime;
            yield return null;
        }

        OnMovementCanceled();
        input.EnableControls(true);
    }
}
