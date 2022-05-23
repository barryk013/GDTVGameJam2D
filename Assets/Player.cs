using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerThoughtBubble;
    [SerializeField] private TextMeshProUGUI playerThoughtText;

    private Coroutine showHintCoroutine;

    private void Awake()
    {
        playerThoughtBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowHint(string hint)
    {
        if(showHintCoroutine == null)
            showHintCoroutine = StartCoroutine(TypeHintCoroutine(hint));

        playerThoughtBubble.SetActive(true);
    }
    public void HideHint()
    {
        if(showHintCoroutine != null)
            StopCoroutine(showHintCoroutine);

        showHintCoroutine = null;
        playerThoughtBubble.SetActive(false);

    }
    IEnumerator TypeHintCoroutine(string hint)
    {
        playerThoughtText.text = string.Empty;
        

        WaitForSeconds timePerCharacter = new WaitForSeconds(Constants.TextTypingInterval / hint.Length);

        int currentCharIndex = 0;

        while (currentCharIndex <= hint.Length)
        {
            string visibleText = hint.Substring(0, currentCharIndex);
            string invisibleText = $"<color=#00000000>{hint.Substring(currentCharIndex)}</color>";

            playerThoughtText.text = visibleText + invisibleText;

            currentCharIndex++;
            yield return timePerCharacter;
        }

        //todo make 5 a variable
        yield return new WaitForSeconds(5);

        playerThoughtBubble.SetActive(false);
    }
}

