using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEventScript : MonoBehaviour
{
    GameObject balltagu;
    BalltaguScript balltaguScript;
    void Start()
    {
        balltagu = GameObject.Find("Balltagu");
        balltaguScript = balltagu.GetComponent<BalltaguScript>();
    }
    public void LeftButtonDown()
    {
        balltaguScript.inputLeft = true;
        //Debug.Log("Left Down!");
    }
    public void LeftButtonUp()
    {
        balltaguScript.inputLeft = false;
        //Debug.Log("Left UP!");
    }
    public void RightButtonDown()
    {
        balltaguScript.inputRight = true;
        //Debug.Log("Right Down!");
    }
    public void RightButtonUp()
    {
        balltaguScript.inputRight = false;
        //Debug.Log("Right UP!");
    }
    
    public void JumpButtonDown()
    {
        balltaguScript.inputJump = true;
    }
    public void JumpButtonUp()
    {
        balltaguScript.inputJump = false;
    }
    public void AttackButtonDown()
    {
        balltaguScript.inputAttack = true;
    }
    public void AttackButtonUp()
    {
        balltaguScript.inputAttack = false;
    }
}
