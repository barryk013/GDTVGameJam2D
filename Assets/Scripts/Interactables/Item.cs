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

    public event Action InteractionEnded;

    public Transform Transform => transform;

    private void Awake()
    {
        itemName.SetActive(false);
        itemDescription.SetActive(false);
        intereactionButton.SetActive(false);
    }

    public void StartInteraction(UIManager playerUI)
    {
        CameraController.Instance.ZoomIn(transform);
        playerUI.ShowItemContextMenu();
    }

    public void StopInteraction()
    {
        CameraController.Instance.ZoomOut();
        itemDescription.SetActive(false);
        itemName.SetActive(false);
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
    public void ItemPickedUp()
    {
        InteractionEnded?.Invoke();
        gameObject.SetActive(false);
    }    
    public void ItemDropped(Vector3 dropLocation)
    {
        transform.position = dropLocation;
        gameObject.SetActive(true);
    }
    public void CloseDescriptionBox()
    {
        InteractionEnded?.Invoke();
    }

    public void DisableInteraction()
    {
        Destroy(this);
    }
}
