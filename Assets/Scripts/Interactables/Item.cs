using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public GameObject itemName;
    public GameObject itemDescription;

    [SerializeField] private GameObject intereactionButton;
    [SerializeField] private Transform cameraFocusPoint;

    public Transform Transform => transform;

    private void Awake()
    {
        itemName.SetActive(false);
        itemDescription.SetActive(false);
        intereactionButton.SetActive(false);
    }

    public void StartInteraction()
    {
        CameraController.Instance.ZoomIn(cameraFocusPoint);
        itemDescription.SetActive(true);
    }

    public void StopInteraction()
    {
        CameraController.Instance.ZoomOut();
        itemDescription.SetActive(false);
    }

    public void Select()
    {
        intereactionButton.SetActive(true);
        itemName.SetActive(true);
    }

    public void Deselect()
    {
        intereactionButton.SetActive(false);
        itemName.SetActive(false);
    }

    public void PickUpItem()
    {
        gameObject.SetActive(false);
    }
    public void DropItem(Vector2 dropLocation)
    {
        transform.position = dropLocation;
        gameObject.SetActive(true);
    }
}
