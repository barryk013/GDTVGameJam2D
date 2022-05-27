using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Grave : MonoBehaviour, IInteractable, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform cameraFocusPoint;
    [SerializeField] private GraveScriptableObject gravePreset;

    [SerializeField] private SpriteRenderer graveSpriteRenderer;
    private Quest _quest;
    public Quest Quest { get { return _quest; } }
    public Story Story { 
        get
        {
            return _quest.Story;
        }
    }

    public event Action InteractionStarted;
    public event Action InteractionEnded;

    public Vector3 Position => transform.position;

    private bool interacting = false;

    void Awake()
    {
        _quest = GetComponent<Quest>(); 
    }
    public void StartInteraction(UIManager playerUI)
    {
        CameraController.Instance.ZoomIn(cameraFocusPoint);
        playerUI.ShowGraveContextMenu(_quest.QuestActive);
        interacting = true;
    }
    public void StopInteraction()
    {;
        CameraController.Instance.ZoomOut();
        _quest.HideDialogue();
        interacting = false;
    }
    public void Select()
    {
        graveSpriteRenderer.material.SetFloat("_ToggleBorder", 1);
    }

    public void Deselect()
    {
        graveSpriteRenderer.material.SetFloat("_ToggleBorder", 0);
    }

    public void Interact()
    {
        _quest.ShowDialogue();
    }
    public void HandInItem(Item item)
    {
        if (item.ItemId != gravePreset.Id)
        {
            Quest.WrongItemHandIn();
            InteractionEnded?.Invoke();
            return;
        }

        Destroy(item.gameObject);

        //item.transform.parent = questItemLocation;
        //item.transform.position = questItemLocation.position;
        //item.gameObject.SetActive(true);
        //item.DisableInteraction();

        _quest.QuestCompleted();
    }

    public void StoryCompleted()
    {
        InteractionEnded?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!interacting)
            InteractionStarted?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //TODO show a different border colour for hover and selected.
        if (!interacting)
            Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!interacting)
            Deselect();
    }
}
