using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private UIPanel itemContextMenu;
    [SerializeField] private UIPanel graveContextMenu;
    [SerializeField] private GameObject graveHandInButton;

    [SerializeField] private Transform contextMenuContainer;
    [SerializeField] private Transform contextMenuPosition;

    [SerializeField] private InputScriptableObject input;

    private void Awake()
    {
        var itemRT = itemContextMenu.GetComponent<RectTransform>();
        var graveRT = graveContextMenu.GetComponent<RectTransform>();
#if UNITY_ANDROID
        itemRT.sizeDelta = new Vector2(itemRT.sizeDelta.x, 5);
        graveRT.sizeDelta = new Vector2(graveRT.sizeDelta.x, 5);
#else
        itemRT.sizeDelta = new Vector2(itemRT.sizeDelta.x, 3);
        graveRT.sizeDelta = new Vector2(graveRT.sizeDelta.x, 3);
#endif
    }

    private void Start()
    {
        CloseContextMenu();
    }
    private void Update()
    {
        contextMenuContainer.transform.position = contextMenuPosition.position;
    }
    

    public void ShowItemContextMenu()
    {        
        graveContextMenu.SetActive(false);
        itemContextMenu.SetActive(true);
        UIManager.Instance.ContextMenuOpen = true;
    }
    public void ShowGraveContextMenu(bool questActive, bool completedStoryRead, string actionName)
    {
        itemContextMenu.SetActive(false);        
        graveContextMenu.SetActive(true);

        if (!questActive || !completedStoryRead)
            graveHandInButton.SetActive(false);
        else
        {
            graveHandInButton.GetComponentInChildren<TextMeshProUGUI>().text = actionName;
            graveHandInButton.SetActive(true);
        }


        UIManager.Instance.ContextMenuOpen = true;
    }

    public void CloseContextMenu()
    {
        itemContextMenu.SetActive(false);
        graveContextMenu.SetActive(false);
        UIManager.Instance.ContextMenuOpen = false;
    }
}
