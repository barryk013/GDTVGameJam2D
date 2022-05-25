using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grave : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private Item questItem;
    [SerializeField] private Transform questItemLocation;

    public Story Story { get; private set; }

    public event Action InteractionEnded;
    public Transform Transform => transform;

    void Awake()
    {
        interactionPrompt.SetActive(false);
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
}
