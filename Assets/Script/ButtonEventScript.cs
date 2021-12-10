using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventScript : MonoBehaviour
{
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
        balltagu = GameObject.Find("Balltagu");
        mainScript = balltagu.GetComponent<BalltaguScript>();
        ability = balltagu.GetComponent<AbilityScript>();
        time = 0;
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
        mainScript.inputAttack = true;
        cooldownTarget = GameObject.Find("AttackButton");
        cooldown = cooldownTarget.GetComponent<CooldownScript>();
        cooldown.cooldownTime = ability.attackDestroyTime + ability.attackSpeed;
        cooldown.starting = true;
    }
    public void AttackButtonUp()
    {
        mainScript.inputAttack = false;
    }



    public void LeftButtonDown()
    {
        mainScript.inputLeft = true;
        //Debug.Log("Left Down!");
    }
    public void LeftButtonUp()
    {
        mainScript.inputLeft = false;
        //Debug.Log("Left UP!");
    }
    public void RightButtonDown()
    {
        mainScript.inputRight = true;
        //Debug.Log("Right Down!");
    }
    public void RightButtonUp()
    {
        mainScript.inputRight = false;
        //Debug.Log("Right UP!");
    }
}
