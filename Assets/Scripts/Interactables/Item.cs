using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public GameObject itemName;
    public GameObject itemDescription;

    [SerializeField] private GameObject intereactionButton;
    [SerializeField] private UIPanel contextMenu;

    private Inventory playerInventory;

    public event Action InteractionFinished;

    public Transform Transform => transform;

    private void Awake()
    {
        itemName.SetActive(false);
        itemDescription.SetActive(false);
        intereactionButton.SetActive(false);
    }

    public void StartInteraction(Inventory playerInventory)
    {
        this.playerInventory = playerInventory;
        CameraController.Instance.ZoomIn(transform);
        //itemDescription.SetActive(true);
        contextMenu.SetActive(true);
    }

    public void StopInteraction()
    {
        this.playerInventory = null;
        CameraController.Instance.ZoomOut();
        itemDescription.SetActive(false);
        itemName.SetActive(false);
        contextMenu.SetActive(false);
    }

    public void Select()
    {
        intereactionButton.SetActive(true);
        itemName.SetActive(true);
    }

    public void Deselect()
    {
        intereactionButton.SetActive(false);        
    }
    public void Inspect()
    {
        itemDescription.SetActive(true);
    }
    public void PickUpItem()
    {
        if (playerInventory == null)
            return;
        playerInventory.PickUp(this);

        InteractionFinished?.Invoke();
    }    
}
