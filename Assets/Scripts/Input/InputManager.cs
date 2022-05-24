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
        Input.Cancel.Cancel.performed += inputScriptableObject.OnInteractionCanceled;

        SwitchToNormalControls();

    }
    private void OnDisable()
    {
        inputScriptableObject.ResetInput();        
        Input.MainControls.Interact.performed -= inputScriptableObject.OnInteractionPerformed;
        Input.Cancel.Cancel.performed -= inputScriptableObject.OnInteractionCanceled;
    }

    public Vector2 ReadMovementVector()
    {
        return Input.MainControls.Move.ReadValue<Vector2>();
    }

    public void SwitchToUIControls()
    {
        print("Switch to UI controls");
        Input.MainControls.Disable();        
    }
    public void SwitchToNormalControls()
    {
        print("Switch to Normal controls");
        Input.MainControls.Enable();        
    }
}
