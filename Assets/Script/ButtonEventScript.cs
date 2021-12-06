using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventScript : MonoBehaviour
{
    private GameObject balltagu;
    private BalltaguScript mainScript;
    void Start()
    {
        balltagu = GameObject.Find("Balltagu");
        mainScript = balltagu.GetComponent<BalltaguScript>();
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

    
    public void JumpButtonDown()
    {
        mainScript.inputJump = true;
    }
    public void JumpButtonUp()
    {
        mainScript.inputJump = false;
    }
    public void AttackButtonDown()
    {
        mainScript.inputAttack = true;
    }
    public void AttackButtonUp()
    {
        mainScript.inputAttack = false;
    }
}
