using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonEventScript : MonoBehaviour
{
    public GameObject[] gameObjects;
    private GameObject cooldownTarget;
    private GameObject balltagu;
    private BalltaguScript mainScript;
    private AbilityScript ability;
    private CooldownScript cooldown;
    public bool jumpButtonDown = false;
    private float time;
    public float dash = 0.25f;
    void Start()
    {
        Close();
        balltagu = GameObject.Find("Balltagu");
        if (balltagu)
        {
            mainScript = balltagu.GetComponent<BalltaguScript>();
            ability = balltagu.GetComponent<AbilityScript>();
            time = 0;
        }
    }
    void Update()
    {
        if (jumpButtonDown)
            time += Time.deltaTime;

        if (time > dash && jumpButtonDown)
        {
            time = 0;
            jumpButtonDown = false;
            mainScript.inputDash = true;
            cooldownTarget = GameObject.Find("JumpButton");
            cooldown = cooldownTarget.GetComponent<CooldownScript>();
            cooldown.cooldownTime = 0.5f + 2.5f / ability.moveSpeed;
            cooldown.starting = true;
        }
        else if (time != 0 && !jumpButtonDown)
        {
            time = 0;
            mainScript.inputJump = true;
        }

        if (mainScript.jumpCount == mainScript.jumpCountMax)
            mainScript.inputJump = false;
    }
    
    public void JumpButtonDown()
    {
        jumpButtonDown = true;
        time = 0;
    }
    public void JumpButtonUp()
    {
        jumpButtonDown = false;
        mainScript.inputDash = false;
        mainScript.inputJump = false;
    }
    public void AttackButtonDown()
    {
        if (balltagu.GetComponent<Animator>().GetInteger("dash") == 0)
        {
            mainScript.inputAttack = true;
            cooldownTarget = GameObject.Find("AttackButton");
            cooldown = cooldownTarget.GetComponent<CooldownScript>();
            cooldown.cooldownTime = ability.attackDestroyTime + ability.attackSpeed;
            cooldown.starting = true;
        }
    }
    public void AttackButtonUp()
    {
        mainScript.inputAttack = false;
    }

    public void Close()
    {
        Time.timeScale = 1;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null) { gameObjects[i].SetActive(false); }
        }
    }

    public void SettingButtonClick()
    {
        gameObjects[0].SetActive(true);
        Time.timeScale = 0;
    }
}
