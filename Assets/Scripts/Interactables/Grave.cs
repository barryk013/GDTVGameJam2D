using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grave : MonoBehaviour
{   

    [SerializeField] private GameObject interactionPrompt;

    private Story story;

    void Awake()
    {
        interactionPrompt.SetActive(false);
        
        story = GetComponent<Story>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactionPrompt.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        interactionPrompt.SetActive(false);
    }

    public void InteractionPerformed()
    {
        story.DisplayStory();
    }
    public void InteractionCanceled()
    {
        story.EndStory();
    }
}
