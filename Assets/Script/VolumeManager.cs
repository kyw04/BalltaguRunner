using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public AudioSource[] audioSource;
    public Slider[] volumeSlider;
    public Text[] volumeText;
    
    void Update()
    {
        for (int i = 0; i < volumeSlider.Length; i++)
        {
            if (volumeSlider[i] != null)
            {
                //if (PlayerPrefs.HasKey(volumeSlider[i].name))
                //{
                //    Debug.Log(volumeSlider[i].name + ", " + volumeSlider[i].value);
                //    volumeSlider[i].value = PlayerPrefs.GetFloat(volumeSlider[i].name); // 뭔가 문제 있음
                //}
                //else
                //{
                //    volumeSlider[i].value = 0.5f; // 뭔가 문제 있음
                //}
                volumeText[i].text = volumeSlider[i].value.ToString("F");
            }
            if (i < audioSource.Length)
            {
                if (PlayerPrefs.HasKey(volumeSlider[i + 1].name))
                    audioSource[i].volume = PlayerPrefs.GetFloat(volumeSlider[i + 1].name);
                else
                    audioSource[i].volume = 0.5f;
                if (PlayerPrefs.HasKey("Volume"))
                    audioSource[i].volume *= PlayerPrefs.GetFloat("Volume");
                else
                    audioSource[i].volume *= 0.5f;
            }
        }
    }
}
