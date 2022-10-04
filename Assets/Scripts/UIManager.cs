using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private UIPanel startMenu;
    [SerializeField] private InputScriptableObject input;

    private bool startMenuOpen = false;
    public bool ContextMenuOpen = false;

    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject menuButton;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

#if !UNITY_ANDROID
        joystick.SetActive(false);
        menuButton.SetActive(false);
#endif
    }

    private void OnEnable()
    {
        input.StartMenuOpened += ToggleStartMenu;        
        startMenu.SetActive(false);
    }
    private void OnDisable()
    {
        input.StartMenuOpened -= ToggleStartMenu;
    }

    public void ToggleStartMenu()
    {
        if (ContextMenuOpen)
            return;

        input.EnableControls(startMenuOpen);
        startMenuOpen = !startMenuOpen;
        startMenu.SetActive(startMenuOpen);
    }

    public void ReturnToMenu()
    {
        LevelLoader.Instance.FadeOut();
        LevelLoader.FadeOutCompleted += LoadMainMenu;        
    }
    private void LoadMainMenu()
    {
        LevelLoader.FadeOutCompleted -= LoadMainMenu;
        SceneManager.LoadScene(0);        
    }
}
