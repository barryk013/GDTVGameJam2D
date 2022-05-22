using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grave : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject interactionPrompt;
    [SerializeField] private Transform cameraFocusPoint;

    public Story Story { get; private set; }

    public Transform Transform => transform;

    void Awake()
    {
        interactionPrompt.SetActive(false);

        Story = GetComponent<Story>();
    }

    public void StartInteraction()
    {
        CameraController.Instance.ZoomIn(cameraFocusPoint);
        Story.StartStory();
    }
    public void StopInteraction()
    {
        CameraController.Instance.ZoomOut();
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
}
