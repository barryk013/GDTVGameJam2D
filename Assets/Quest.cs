using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public Story Story { get; private set; }
    public List<Transform> Gates = new List<Transform>();

    public bool QuestActive = true;

    public event Action<TextScriptableObject> ShowHint;

    private void Awake()
    {
        Story = GetComponent<Story>();
    }

    public void QuestCompleted()
    {        
        QuestActive = false;
        ShowDialogue();
        foreach (var gate in Gates)
        {
            TilemapManager.Instance.RemoveTile(gate.position);
        }
    }

    public void ShowDialogue()
    {
        if (QuestActive)        
            Story.ShowStory();            
        
        else        
            Story.ShowQuestCompletedStory();        
    }
    public void StoryCompleted()
    {
        if (QuestActive)
        {
            ShowHint?.Invoke(Story.GetHint());
        }
        HideDialogue();

    }

    public void HideDialogue()
    {
        Story.EndStory();
    }

    private void OnDrawGizmos()
    {
        foreach (var gate in Gates)
        {
            Gizmos.DrawWireSphere(gate.position, 2);
        }
    }
}
