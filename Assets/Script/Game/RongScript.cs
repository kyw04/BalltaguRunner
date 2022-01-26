using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class RongScript : MonoBehaviour
{
    GameObject player;
    AbilityScript playerAbility;
    AbilityScript ability;
    //private bool hpBar = false;
    public bool isPlayer = false;
    public bool isJumpingTime = false;
    public bool jumpingTimeStart = false;
    private float jumpTimes;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Balltagu");
        playerAbility =  player.GetComponent<AbilityScript>();
        ability = this.GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (!gameObject.GetComponent<Animator>().GetBool("isJumping") && isJumpingTime)
        {
            gameObject.GetComponent<Animator>().SetBool("isJumping", true);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isJumpingTime = false;
            if (isPlayer)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ability.moveSpeed * 5.0f, ability.jumpPower * 2.0f));
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ability.moveSpeed, ability.jumpPower));
            }
        }
        if (!gameObject.GetComponent<Animator>().GetBool("isJumping") && !jumpingTimeStart && !isJumpingTime)
        {
            gameObject.GetComponent<Animator>().Play("rong_idle");
            jumpingTimeStart = true;
            if (isPlayer) { jumpTimes = 0.5f; }
            else { jumpTimes = 0.25f; }

            StartCoroutine(jumping_time());
        }
        if (ability.hp <= 0)
        {
            player.GetComponent<BalltaguScript>().score += 6;
            Destroy(this.gameObject);
        }
    }
    IEnumerator jumping_time()
    {
        yield return new WaitForSeconds(jumpTimes);
        isJumpingTime = true;
        jumpingTimeStart = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            gameObject.GetComponent<Animator>().SetBool("isJumping", false);
        }
    }
}
