using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider backgroundMusicVolumeSlider;
    [SerializeField] private AudioMixer mixer;

    private string _backgrounMusicVolume = "BackgroundMusicVolume";
    [SerializeField] private float multiplier = 30;

    private void OnEnable()
    {
        backgroundMusicVolumeSlider.onValueChanged.AddListener(OnBackgroundMusicVolumeChanged);

        mixer.GetFloat(_backgrounMusicVolume, out float volume);
        backgroundMusicVolumeSlider.SetValueWithoutNotify(volume);
    }
    private void OnDisable()
    {
        backgroundMusicVolumeSlider.onValueChanged.RemoveListener(OnBackgroundMusicVolumeChanged);
    }

    private void OnBackgroundMusicVolumeChanged(float value)
    {
        mixer.SetFloat(_backgrounMusicVolume, value);
    }
}
