using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private string[] volumeName = { "Volume", "BackgroundVolume", "EffectVolume" };
    private GameObject volume;
    public AudioSource[] audioSource;
    public Text[] volumeText;
    public GameObject setting;

    void Start()
    {

    }

    void Update()
    {
        if (setting != null)
        for (int i = 0; i < volumeName.Length; i++)
        {
            volume = GameObject.Find(volumeName[i]);
            if (volume != null)
            {
                Slider slider = volume.GetComponent<Slider>();
                if (PlayerPrefs.HasKey(volume.name))
                {
                    Debug.Log(PlayerPrefs.GetFloat(volume.name));
                    slider.value = PlayerPrefs.GetFloat(volume.name); // 뭔가 문제 있음
                }
                else
                {
                    slider.value = 0.5f;
                }
                volumeText[i].text = slider.value.ToString("F");
            }
            if (i < audioSource.Length && volumeName[i + 1] != null)
            {
                if (PlayerPrefs.HasKey(volumeName[i + 1]))
                    audioSource[i].volume = PlayerPrefs.GetFloat(volumeName[i + 1]);
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
