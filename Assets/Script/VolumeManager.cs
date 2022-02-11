using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;
    public Text volumeText;
    void Update()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("Volume");
            if (volumeSlider) 
            { 
                volumeSlider.value = PlayerPrefs.GetFloat("Volume");
                volumeText.text = volumeSlider.value.ToString("F");
            }
        }
        else
        {
            audioSource.volume = 0.5f;
            if (volumeSlider) 
            { 
                volumeSlider.value = 0.5f;
                volumeText.text = volumeSlider.value.ToString("F");
            }
        }
    }
}
