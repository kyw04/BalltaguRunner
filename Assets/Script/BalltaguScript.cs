using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalltaguScript : MonoBehaviour
{
    public GameObject AttackBox;
    AbilityScript ability;
    public bool inputLeft = false;
    public bool inputRight = false;
    public bool inputJump = false;
    public bool inputAttack = false;

    private bool isJumping = false;
    private int jumpCountMax = 1;
    private int doublejumpCount;
    //private float jumpTimer;
    //private float jumpTimeLimit = 0.1f;
    private bool attackTime = false;

    private float moveSet;
    private Vector3 mainCamera;
    private Vector3 player;
    //Start is called before the first frame updatek
    void Start()
    {
        ability = this.GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
        if (!inputLeft && !inputRight)
        {
            this.gameObject.GetComponent<Animator>().SetBool("isWalk", false);
        }
        if (inputLeft)
        {
            gameObject.GetComponent<Animator>().SetBool("isWalk", true);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.transform.position += new Vector3(-ability.moveSpeed, 0, 0) * Time.deltaTime;
        }
        if (inputRight)
        {
            gameObject.GetComponent<Animator>().SetBool("isWalk", true);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            gameObject.transform.position += new Vector3(ability.moveSpeed, 0, 0) * Time.deltaTime;
        }

        if (inputJump && !isJumping)
        {
            isJumping = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ability.jumpPower, ForceMode2D.Force);
        }
        //if (inputJump && jumpTimer < jumpTimeLimit)
        //{
        //    isJumping = true;

        //    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //    gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower * ((jumpTimer * 10) + 1f), ForceMode2D.Impulse);

        //    jumpTimer += Time.deltaTime;
        //}
        if (isJumping && !inputJump && doublejumpCount < jumpCountMax)
        {
            doublejumpCount++;
            isJumping = false;
        }
        //if (!isJumping)
        //{
        //    jumpTimer = 0.0f;
        //}

        if (inputAttack && !attackTime && !GetComponent<Animator>().GetBool("isAttack"))
        {
            attackTime = true;
            GetComponent<Animator>().SetBool("isAttack", true);
            GameObject newAttackBox = Instantiate(AttackBox);
            newAttackBox.transform.position = transform.position + new Vector3(1, 0, 0);
            StartCoroutine(attack_time(newAttackBox));
        }

        mainCamera = Camera.main.transform.position + new Vector3(-6.25f, 0, 0);
        player = gameObject.transform.position;
        if (player.x < mainCamera.x)
            moveSet = 1;
        else
            moveSet = -1;
       
        if (player.x < mainCamera.x + 0.125f && player.x < mainCamera.x - 0.125f || player.x > mainCamera.x + 0.125f && player.x > mainCamera.x - 0.125f)
            gameObject.transform.position += new Vector3(moveSet * 5, 0, 0) * Time.deltaTime;

        if (ability.hp > ability.maxHp)
        {
            ability.hp = ability.maxHp;
        }
    }

    IEnumerator invincibility_time()
    {
        gameObject.layer = 8;
        for (int i = 0; i < 4; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.5f);
        }
        gameObject.layer = 6;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
    IEnumerator attack_time(GameObject attack)
    {
        yield return new WaitForSeconds(ability.attackDestroyTime);
        Destroy(attack.gameObject);
        GetComponent<Animator>().SetBool("isAttack", false);
        yield return new WaitForSeconds(ability.attackSpeed);
        attackTime = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
            doublejumpCount = 0;
        }
        
        if (collision.gameObject.tag == "Monster")
        {
            StartCoroutine(invincibility_time());
        }
    }
}
