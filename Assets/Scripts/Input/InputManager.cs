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
        Input.AlwaysOn.Cancel.performed += inputScriptableObject.OnInteractionCanceled;
        Input.AlwaysOn.Menu.performed += inputScriptableObject.OnStartMenuOpened;

        EnableControls(true);

    }
    private void OnDisable()
    {
        inputScriptableObject.ResetInput();        
        Input.MainControls.Interact.performed -= inputScriptableObject.OnInteractionPerformed;
        Input.AlwaysOn.Cancel.performed -= inputScriptableObject.OnInteractionCanceled;
        Input.AlwaysOn.Menu.performed -= inputScriptableObject.OnStartMenuOpened;
    }

    public Vector2 ReadMovementVector()
    {
        return Input.MainControls.Move.ReadValue<Vector2>();
    }

    public void EnableControls(bool enabled)
    {
        if(enabled)
            Input.MainControls.Enable();
        else
            Input.MainControls.Disable();
    }
}
