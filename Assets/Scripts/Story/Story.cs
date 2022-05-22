using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Story : MonoBehaviour
{
    [SerializeField] private GameObject textBubble;
    [SerializeField] private TextMeshProUGUI storyText;
    [SerializeField] private List<TextScriptableObject> paragraphs = new List<TextScriptableObject>();
    [SerializeField] private TextScriptableObject hint;

    [SerializeField] private float textTypingInterval = 2;

    private int currentParagraphIndex = 0;

    private bool storyInProgress = false;

    public event Action<string> StoryCompleted;

    private void Awake()
    {
        textBubble.SetActive(false);
    }

    public void StartStory()
    {
        if(storyInProgress) return;

        storyInProgress = true;
        textBubble.SetActive(true);

        currentParagraphIndex = 0;
        StartCoroutine(TypeStoryCoroutine());
    }

    public void EndStory()
    {
        textBubble.SetActive(false);
        storyText.text = string.Empty;
        storyInProgress = false;

        StopAllCoroutines();
        currentParagraphIndex = 0;
    }

    public void NextPage()
    {
        if (currentParagraphIndex == paragraphs.Count - 1)
        {
            StoryCompleted?.Invoke(hint.Text);
            EndStory();
            return;
        }

        StopAllCoroutines();
        currentParagraphIndex++;
        StartCoroutine(TypeStoryCoroutine());
    }
    public void PreviousPage()
    {
        if (currentParagraphIndex == 0)
            return;
        
        StopAllCoroutines();
        currentParagraphIndex--;
        storyText.text = paragraphs[currentParagraphIndex].Text;
    }

    public string GetHint()
    {
        return hint.Text;
    }

    IEnumerator TypeStoryCoroutine()
    {
        storyText.text = string.Empty;
        string textToWrite = paragraphs[currentParagraphIndex].Text;

        WaitForSeconds timePerCharacter = new WaitForSeconds(textTypingInterval / textToWrite.Length);
        
        int currentCharIndex = 0;

        while(currentCharIndex <= textToWrite.Length)
        {
            string visibleText = textToWrite.Substring(0, currentCharIndex);
            string invisibleText = $"<color=#00000000>{textToWrite.Substring(currentCharIndex)}</color>";

            storyText.text = visibleText + invisibleText;

            currentCharIndex++;
            yield return timePerCharacter;
        }  
    }
}
