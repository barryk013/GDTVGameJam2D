using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class Grave : MonoBehaviour, IInteractable, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Item questItem;
    [SerializeField] private Transform questItemLocation;

    [SerializeField] private SpriteRenderer graveSpriteRenderer;

    public Story Story { get; private set; }

    public event Action InteractionStarted;
    public event Action InteractionEnded;

    public Vector3 Position => transform.position;

    void Awake()
    {
        Story = GetComponent<Story>();
    }
    public void StartInteraction(UIManager playerUI)
    {
        CameraController.Instance.ZoomIn(transform);
        playerUI.ShowGraveContextMenu();
    }
    public void StopInteraction()
    {;
        CameraController.Instance.ZoomOut();
        Story.EndStory();
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
        Story.ShowStory();
    }
    public void HandInItem(Item itemInHand)
    {
        if (itemInHand == null || itemInHand != questItem)
        {
            Story.ShowWrongItemStory();
            return;
        }

        itemInHand.transform.parent = questItemLocation;
        itemInHand.transform.position = questItemLocation.position;        
        itemInHand.gameObject.SetActive(true);
        itemInHand.DisableInteraction();

        Story.ShowQuestCompletedStory();
    }

    public void StoryCompleted()
    {
        InteractionEnded?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        InteractionStarted?.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //TODO show a different border colour for hover and selected.
        Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Deselect();
    }
}
