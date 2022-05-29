using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutomaticStory : MonoBehaviour
{
    [SerializeField] private List<TextScriptableObject> paragraphs = new List<TextScriptableObject>();
    [SerializeField] private GameObject textBoxGO;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private AudioClip voiceClip;

    [SerializeField] private float oneEnd;
    [SerializeField] private float twoEnd;
    [SerializeField] private float threeEnd;
    [SerializeField] private float fourEnd;

    private bool storyPlaying = false;

    private void Awake()
    {
        textBoxGO.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (storyPlaying) return;

        if (collision.CompareTag(Constants.PlayerTag))
        {
            
            storyPlaying = true;
            textBoxGO.SetActive(true);
            StartCoroutine(Timer());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.PlayerTag))
        {
            StopStory();
        }
    }

    private void StopStory()
    {
        storyPlaying = false;
        textBoxGO.SetActive(false);
        StopAllCoroutines();
        AudioManager.Instance.StopNarration();
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);

        AudioManager.Instance.PlayVoiceClip(voiceClip);

        int currentParagraph = -1;
        float timer = 0;
        while (timer < fourEnd)
        {
            if(timer < oneEnd && timer >= 0)
            {
                if(currentParagraph != 0)
                {
                    currentParagraph = 0;
                    StartCoroutine(StartStory(currentParagraph, oneEnd));
                }
            }
            else if(timer < twoEnd && timer >= oneEnd)
            {
                if (currentParagraph != 1)
                {
                    currentParagraph = 1;
                    StartCoroutine(StartStory(currentParagraph, twoEnd - oneEnd));
                }
            }
            else if(timer < threeEnd && timer >= twoEnd)
            {
                if (currentParagraph != 2)
                {
                    currentParagraph = 2;
                    StartCoroutine(StartStory(currentParagraph, threeEnd - twoEnd));
                }
            }
            else if(timer < fourEnd && timer >= threeEnd)
            {
                if (currentParagraph != 3)
                {
                    currentParagraph = 3;
                    StartCoroutine(StartStory(currentParagraph, fourEnd - threeEnd));
                }
            }
            else
            {
                yield break;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2);
        StopStory();
    }

    IEnumerator StartStory(int index, float clipLength)
    {        
        textBox.text = string.Empty;
        
        int currentCharIndex = 0;

        WaitForSeconds timePerCharacter = new WaitForSeconds(clipLength * 0.75f / paragraphs[index].Text.Length);

        while (currentCharIndex <= paragraphs[index].Text.Length)
        {
            string visibleText = paragraphs[index].Text.Substring(0, currentCharIndex);
            string invisibleText = $"<color=#00000000>{paragraphs[index].Text.Substring(currentCharIndex)}</color>";

            textBox.text = visibleText + invisibleText;

            currentCharIndex++;            
            yield return timePerCharacter;
        }
    }


}
