using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider backgroundMusicVolumeSlider;
    [SerializeField] private AudioMixer mixer;

    private string bgmName = "BackgroundMusicVolume";
    [SerializeField] private float multiplier = 30;

    private void OnEnable()
    {
        backgroundMusicVolumeSlider.onValueChanged.AddListener(OnBackgroundMusicVolumeChanged);

        mixer.GetFloat(bgmName, out float volume);
        backgroundMusicVolumeSlider.SetValueWithoutNotify(volume);
    }
    private void OnDisable()
    {
        backgroundMusicVolumeSlider.onValueChanged.RemoveListener(OnBackgroundMusicVolumeChanged);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBackgroundMusicVolumeChanged(float value)
    {
        mixer.SetFloat(bgmName, value);
    }
}
