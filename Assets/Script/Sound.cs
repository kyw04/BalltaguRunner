using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sound;
    public static Sound instance;

    void Awake()
    {
        if (Sound.instance == null) { Sound.instance = this; }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int index)
    {
        audioSource.PlayOneShot(sound[index]);
    }
}
