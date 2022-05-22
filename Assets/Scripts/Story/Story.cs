using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Story : MonoBehaviour
{
    [SerializeField] private GameObject textBubble;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<TextScriptableObject> paragraphs = new List<TextScriptableObject>();    

    private int currentParagraphIndex = 0;

    public bool storyInProgress = false;

    private void Awake()
    {
        textBubble.SetActive(false);
    }

    public void DisplayStory()
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
        text.text = string.Empty;
        storyInProgress = false;

        StopAllCoroutines();
        currentParagraphIndex = 0;
    }

    public void NextPage()
    {
        if (currentParagraphIndex == paragraphs.Count - 1)
            return;

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
        StartCoroutine(TypeStoryCoroutine());
    }

    IEnumerator TypeStoryCoroutine()
    {
        text.text = string.Empty;
        WaitForSeconds interval = new WaitForSeconds( 1 / paragraphs[currentParagraphIndex].LettersPerSecond);

        foreach (var letter in paragraphs[currentParagraphIndex].Text)
        {
            text.text += letter;
            yield return interval;
        }        
    }
}
