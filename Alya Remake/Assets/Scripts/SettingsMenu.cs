using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider ambienceSlider;
    public Slider playerSlider;
    public Slider uiSlider;

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        ambienceSlider.value = PlayerPrefs.GetFloat("AmbienceVolume", 1.0f);
        playerSlider.value = PlayerPrefs.GetFloat("PlayerVolume", 1.0f);
        uiSlider.value = PlayerPrefs.GetFloat("UIVolume", 1.0f);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetAmbienceVolume(float volume)
    {
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("AmbienceVolume", volume);
    }

    public void SetPlayerVolume(float volume)
    {
        audioMixer.SetFloat("PlayerVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("PlayerVolume", volume);
    }

    public void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("UIVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("UIVolume", volume);
    }

}
