using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SLManager : MonoBehaviour
{
    public Slider volume;
    private static SLManager instance;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void VolumeSave()
    {
        PlayerPrefs.SetFloat("Volume", volume.value);
    }
}
