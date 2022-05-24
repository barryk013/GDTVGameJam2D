using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grave : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private Item questItem;

    [SerializeField] private UIPanel contextMenu;

    public Story Story { get; private set; }

    private Item itemInPlayerHand;

    public event Action InteractionFinished;

    public Transform Transform => transform;

    void Awake()
    {
        interactionPrompt.SetActive(false);
        contextMenu.SetActive(false);
        Story = GetComponent<Story>();
    }

    public void StartInteraction(Inventory playerInventory)
    {
        this.itemInPlayerHand = playerInventory.Item;
        CameraController.Instance.ZoomIn(transform);
        //Story.ShowStory();
        contextMenu.SetActive(true);
    }
    public void StopInteraction()
    {
        itemInPlayerHand = null;
        CameraController.Instance.ZoomOut();
        contextMenu.SetActive(false);
        Story.EndStory();
    }
    public string GetHint()
    {
        return Story.GetHint();
    }

    public void Select()
    {
        interactionPrompt.SetActive(true);
    }

    public void Deselect()
    {
        interactionPrompt.SetActive(false);
    }

    public void Interact()
    {
        Story.ShowStory();
    }
    public void HandInItem()
    {
        if(itemInPlayerHand != questItem) 
            Story.ShowWrongItemStory();

        Story.ShowQuestCompletedStory();
    }

    internal void InteractionCompleted()
    {
        InteractionFinished?.Invoke();
    }
}
