using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScript : MonoBehaviour
{
    public Image cooldown_image;
    public Text cooldown_text;
    public bool isReady = true;
    public bool starting = false;
    public float cooldownTime;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (starting && isReady)
        {
            starting = false;
            isReady = false;
            StartCoroutine(startCooldown(cooldownTime));
        }
    }

    IEnumerator startCooldown(float time)
    {
        float start = time;
        while (time > 0)
        {
            time -= Time.deltaTime;
            float temp = (float)(Math.Round(time * 10) / 10);
            cooldown_text.text = temp.ToString();
            cooldown_image.fillAmount = time / start;
            yield return new WaitForFixedUpdate();
        }
        cooldown_text.text = "";
        isReady = true;
    }
}
