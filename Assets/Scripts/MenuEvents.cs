using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioMixer;
    private float value;

    private void Start()
    {
        audioMixer.GetFloat("volume",out value);
        slider.value = value; 
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

    }
}
