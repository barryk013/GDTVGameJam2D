using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputScriptableObject inputScriptableObject;
    
    private PlayerControls input;
    public PlayerControls Input
    {
        get
        {
            if (input == null)
            {
                input = new PlayerControls();
                input.Enable();
            }
            return input;
        }
    }

    private void OnEnable()
    {
        inputScriptableObject.SetInputManager(this);

        Input.MainControls.Interact.performed += inputScriptableObject.OnInteractionPerformed;
        Input.MainControls.Cancel.performed += inputScriptableObject.OnInteractionCanceled;
        Input.MainControls.PickUp.performed += inputScriptableObject.OnPickUpActionPerformed;
    }
    private void OnDisable()
    {
        inputScriptableObject.ResetInput();        
        Input.MainControls.Interact.performed -= inputScriptableObject.OnInteractionPerformed;
        Input.MainControls.Cancel.performed -= inputScriptableObject.OnInteractionCanceled;
        Input.MainControls.PickUp.performed -= inputScriptableObject.OnPickUpActionPerformed;
    }

    public Vector2 ReadMovementVector()
    {
        return Input.MainControls.Move.ReadValue<Vector2>();
    }
}
