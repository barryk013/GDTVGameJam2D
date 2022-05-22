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
    #endregion

    #region Event Listeners
    public void OnInteractionPerformed(InputAction.CallbackContext obj) { InteractionPerformed?.Invoke(); }
    public void OnInteractionCanceled(InputAction.CallbackContext obj) { InteractionCanceled?.Invoke(); }    
    public void OnPickUpActionPerformed(InputAction.CallbackContext obj) { PickUpActionPerformed?.Invoke(); }

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
        get => inputManager.ReadMovementVector();
    }
    #endregion
}
