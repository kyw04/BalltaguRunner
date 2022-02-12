using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SLManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void VolumeSave()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        GameObject slider = GameObject.Find(name);
        if (slider != null)
        {
            Slider volume = slider.GetComponent<Slider>();
            PlayerPrefs.SetFloat(name, volume.value);
        }
    }
}
