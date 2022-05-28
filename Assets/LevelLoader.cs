using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance { get; private set; }
    [SerializeField] private CanvasGroup blackScreen;
    [SerializeField] private AudioManager audioManager;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
        blackScreen.alpha = 1;
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float timer = 0;
        while (timer < Constants.FadeTime)
        {
            float percent = timer / Constants.FadeTime;
            blackScreen.alpha = 1 - percent;
            audioManager.SetVolume(percent);

            timer += Time.deltaTime;
            yield return null;
        }
    }

    public void LoadLevel(int level)
    {
        StartCoroutine(LoadLevelCoroutine(1));
    }
    IEnumerator LoadLevelCoroutine(int level)
    {
        float timer = 0;
        while (timer < Constants.FadeTime)
        {
            float percent = timer / Constants.FadeTime;
            blackScreen.alpha = percent;
            audioManager.SetVolume(1 - percent);
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(level);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
