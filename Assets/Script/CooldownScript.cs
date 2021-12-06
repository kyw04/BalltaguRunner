using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownScript : MonoBehaviour
{
    public Image cooldown_image;
    public Text cooldown_text;
    private GameObject balltagu;
    private BalltaguScript mainScript;
    private AbilityScript ability;
    private float atttck_cooldown_time;
    private bool cooltime = false;
    // Start is called before the first frame update
    void Start()
    {
        balltagu = GameObject.Find("Balltagu");
        ability = balltagu.GetComponent<AbilityScript>();
        mainScript = balltagu.GetComponent<BalltaguScript>();
    }

    // Update is called once per frame
    void Update()
    {
        atttck_cooldown_time = ability.attackDestroyTime + ability.attackSpeed;

        if (mainScript.inputAttack && !cooltime)
            StartCoroutine(cooldown(atttck_cooldown_time));
    }

    IEnumerator cooldown(float time)
    {
        cooltime = true;
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
        cooltime = false;
    }
}
