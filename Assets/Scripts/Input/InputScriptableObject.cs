using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName ="Input Events Scriptable Object")]
public class InputScriptableObject : ScriptableObject
{
    private InputManager inputManager;

    #region Events
    public event Action InteractionPerformed;
    public event Action InteractionCanceled;
    public event Action PickUpActionPerformed;
    public event Action NextPage;
    public event Action PreviousPage;
    #endregion

    #region Event Listeners
    public void OnInteractionPerformed(InputAction.CallbackContext obj) { InteractionPerformed?.Invoke(); }
    public void OnInteractionCanceled(InputAction.CallbackContext obj) { InteractionCanceled?.Invoke(); }    
    public void OnNextPagePerformed(InputAction.CallbackContext obj) { NextPage?.Invoke(); }
    public void OnPreviousPagePerformed(InputAction.CallbackContext obj) { PreviousPage?.Invoke(); }

    public void SetInputManager(InputManager inputManager)
    {
        this.inputManager = inputManager;
    }
    public void ResetInput()
    {
        inputManager = null;
    }
    #endregion

    #region Values
    public Vector2 MovementVector
    {
        get 
        { 
            return inputManager == null ? Vector2.zero : inputManager.ReadMovementVector(); 
        }
    }
    #endregion

    public void SwitchToUIControls()
    {
        inputManager.SwitchToUIControls();
    }
    public void SwitchToNormalControls()
    {
        inputManager.SwitchToNormalControls();
    }

}
