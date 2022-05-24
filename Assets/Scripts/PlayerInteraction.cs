using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InputScriptableObject input;

    [SerializeField] private List<IInteractable> interactableObjects = new List<IInteractable>();
    private IInteractable selectedObject;
    private Coroutine interactionCoroutine;

    private Inventory inventory = new Inventory();

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }


    private void OnEnable()
    {
        input.InteractionPerformed += OnInteractionPerformed;
        input.InteractionCanceled += OnInteractionCanceled;
    }
    private void OnDisable()
    {
        input.InteractionPerformed -= OnInteractionPerformed;
        input.InteractionCanceled -= OnInteractionCanceled;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactableObject = other.GetComponent<IInteractable>();

        if (interactableObject == null)
            return;


        interactableObjects.Add(interactableObject);

        if (interactionCoroutine == null)
            interactionCoroutine = StartCoroutine(InteractionCoroutine());
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactableObject = other.GetComponent<IInteractable>();

        if (interactableObject == null)
            return;

        interactableObjects.Remove(interactableObject);

        if (interactableObjects.Count == 0)
        {
            if(interactionCoroutine != null)
            {
                StopCoroutine(interactionCoroutine);
                interactionCoroutine = null;
            }

            if (selectedObject != null)
            {
                selectedObject.Deselect();
                selectedObject.StopInteraction();
                //selectedObject = null;
            }
        }
    }

    #region event listeners
    private void OnInteractionPerformed()
    {
        if (selectedObject == null)
            return;

        player.HideHint();
        selectedObject.StartInteraction(inventory);

        selectedObject.InteractionFinished += OnInteractionCanceled;

        if (selectedObject is Grave)
        {
            Grave grave = (Grave)selectedObject;
            grave.Story.ShowQuestHint += OnShowHint;
        }

        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
            interactionCoroutine = null;
        }
        if (selectedObject != null)
        {
            selectedObject.Deselect();            
        }
            
        input.SwitchToUIControls();
    }
    private void OnInteractionCanceled()
    {
        
        if (selectedObject == null)
            return;

        selectedObject.InteractionFinished -= OnInteractionCanceled;

        selectedObject.StopInteraction();

        if (selectedObject is Grave)
        {
            Grave grave = (Grave)selectedObject;
            grave.Story.ShowQuestHint -= OnShowHint;
        }

        if (interactionCoroutine == null)
            interactionCoroutine = StartCoroutine(InteractionCoroutine());

        input.SwitchToNormalControls();
    }
    private void OnShowHint(string hint)
    {
        player.ShowHint(hint);        
    }    
    #endregion


    #region Interaction 
    IEnumerator InteractionCoroutine()
    {
        selectedObject = null;
        while (true)
        {
            if(interactableObjects == null || interactableObjects.Count == 0)
                yield break;

            IInteractable closestObj = FindClosestObject();

            if (closestObj != selectedObject)            
                SelectNewObject(closestObj);            

            yield return null;
        }
    }

    private IInteractable FindClosestObject()
    {
        float minSqrDist = float.MaxValue;
        IInteractable closestObj = null;

        foreach (IInteractable obj in interactableObjects)
        {
            float sqrDistToObj = Vector2.SqrMagnitude(obj.Transform.position - transform.position);
            if (sqrDistToObj < minSqrDist)
            {
                closestObj = obj;
                minSqrDist = sqrDistToObj;
            }
        }

        return closestObj;
    }

    private void SelectNewObject(IInteractable closestObj)
    {
        //deselect old object
        if (selectedObject != null)
        {
            selectedObject.Deselect();
            selectedObject.StopInteraction();
        }


        if (closestObj != null)
            closestObj.Select();

        selectedObject = closestObj;
    }
    #endregion
}
