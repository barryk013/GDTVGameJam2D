using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIPanel itemContextMenu;
    [SerializeField] private UIPanel graveContextMenu;
    [SerializeField] private GameObject contextMenuCancelButton;

    [SerializeField] private Transform contextMenuContainer;
    [SerializeField] private Transform contextMenuLocation;

    [SerializeField] private UIPanel startMenu;

    [SerializeField] private InputScriptableObject input;

    private bool contextMenuOpen = false;
    private bool startMenuOpen = false;

    private void Awake()
    {
        input.StartMenuOpened += ToggleStartMenu;

        CloseContextMenu();
        startMenu.SetActive(false);
    }

    private void Update()
    {
        contextMenuContainer.transform.position = contextMenuLocation.position;
    }

    public void ShowItemContextMenu()
    {        
        graveContextMenu.SetActive(false);
        contextMenuCancelButton.SetActive(true);
        itemContextMenu.SetActive(true);
        contextMenuOpen = true;
    }
    public void ShowGraveContextMenu()
    {
        itemContextMenu.SetActive(false);        
        contextMenuCancelButton.SetActive(true);
        graveContextMenu.SetActive(true);
        contextMenuOpen = true;
    }

    public void CloseContextMenu()
    {
        itemContextMenu.SetActive(false);
        graveContextMenu.SetActive(false);
        contextMenuCancelButton.SetActive(false);
        contextMenuOpen = false;
    }

    private void ToggleStartMenu()
    {
        if (contextMenuOpen)
            return;

        input.EnableControls(startMenuOpen);
        startMenuOpen = !startMenuOpen;
        startMenu.SetActive(startMenuOpen);
    }
}
