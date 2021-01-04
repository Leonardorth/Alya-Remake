using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioClip hover;
    public AudioClip click;
    public AudioSource audio;

    private void Awake()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
    public void PlayHover()
    {
        audio.clip = hover;
        audio.Play();
    }
    public void PlayClick()
    {
        audio.clip = click;
        audio.Play();
    }
}
