using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalltaguScript : MonoBehaviour
{
    public Text score;
    public Text GameOverScoreText;
    public GameObject AttackBox;
    public GameObject GameOver;
    private AbilityScript ability;
    public bool inputJump = false;
    public bool inputAttack = false;
    public bool inputDash = false;
    
    public bool Dashing = false;
    private bool isJumping = false;
    public int jumpCountMax = 2;
    public int jumpCount;
    //private float jumpTimer;
    //private float jumpTimeLimit = 0.1f;
    public bool attackTime = false;

    private float moveSet;
    private Vector3 mainCamera;
    private Vector3 player;

    //Start is called before the first frame updatek
    void Start()
    {
        GameOver.SetActive(false);
        GameObject.Find("EventSystem").GetComponent<ChangeScene>().StartScene();
        ability = this.GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) // 나가기
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.D))
            PlayerPrefs.DeleteAll();

        if (inputJump && (!isJumping || jumpCount < jumpCountMax)) // 점프
        {
            inputJump = false;
            isJumping = true;
            jumpCount++;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * ability.jumpPower, ForceMode2D.Force);
            if (jumpCount == 2)
            {
                GetComponent<Animator>().Play("balltagu_double_jump");
                GetComponent<Animator>().SetBool("isDoubleJump", true);
            }
        }

        if (inputDash && !Dashing) // 대쉬
        {
            inputDash = false;
            StartCoroutine(dash());
        }

        if (inputAttack && !attackTime && !GetComponent<Animator>().GetBool("isAttack") && GetComponent<Animator>().GetInteger("dash") == 0) // 공격
        {
            attackTime = true;
            GetComponent<Animator>().Play("balltagu_attack");
            GetComponent<Animator>().SetBool("isAttack", true);
            GetComponent<Animator>().SetBool("isDoubleJump", false);
            GameObject newAttackBox = Instantiate(AttackBox);
            newAttackBox.transform.position = transform.position + new Vector3(1, 0, 0);
            StartCoroutine(attack_time(newAttackBox));
        }

        // 캐릭터 이동
        mainCamera = Camera.main.transform.position + new Vector3(-6.25f, 0, 0);
        player = gameObject.transform.position;
        if (player.x < mainCamera.x)
            moveSet = 1;
        else
            moveSet = -1;

        if (player.x < mainCamera.x + 0.125f && player.x < mainCamera.x - 0.125f || player.x > mainCamera.x + 0.125f && player.x > mainCamera.x - 0.125f) 
            if (GetComponent<Rigidbody2D>().constraints != RigidbodyConstraints2D.FreezeAll)
                gameObject.transform.position += new Vector3(moveSet * 5, 0, 0) * Time.deltaTime;
        //

        if (ability.hp <= 0) // 사망 메세지
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
            GameOverScoreText.text = score.GetComponent<TextUpdate>().text_data;
        }
    }

    IEnumerator invincibility_time() // 무적
    {
        gameObject.layer = 8;
        for (int i = 0; i < 4; i++) // 깜빡이
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90);
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 180);
            yield return new WaitForSeconds(0.5f);
        }
        gameObject.layer = 6;
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }
    IEnumerator attack_time(GameObject attack) // 공격 속도
    {
        yield return new WaitForSeconds(ability.attackDestroyTime);
        Destroy(attack.gameObject); // 공겨 히트 박스 삭제
        GetComponent<Animator>().SetBool("isAttack", false);
        yield return new WaitForSeconds(ability.attackSpeed);
        attackTime = false;
    }
    IEnumerator dash() // 대쉬
    {
        int rand = Random.Range(1, 3);
        Dashing = true;
        gameObject.layer = 8; // 무적 레이어로 변경
        GetComponent<Animator>().Play("balltagu_dash_" + rand);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1500.0f, 0), ForceMode2D.Force); // 앞으로 대쉬
        GetComponent<Animator>().SetInteger("dash", rand);
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 90); // 색상 변경
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("isDoubleJump", false);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; // 공중에 남아있기       
        yield return new WaitForSeconds(0.5f);
        gameObject.layer = 6; // 기본 레이어로 변경
        gameObject.GetComponent<Animator>().SetInteger("dash", 0); // 에니메이션 변경
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); // 색상 변경
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation; //| RigidbodyConstraints2D.FreezePositionX;
        yield return new WaitForSeconds(2.5f / ability.moveSpeed);
        Dashing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") // 바닥 밟음
        {
            isJumping = false;
            jumpCount = 0;
            GetComponent<Animator>().Play("balltagu_walk");
            GetComponent<Animator>().SetBool("isDoubleJump", false);
        }
        
        if (collision.gameObject.tag == "Monster") // 몬스터 충돌
        {
            StartCoroutine(invincibility_time());
            ability.hp -= collision.gameObject.GetComponent<AbilityScript>().attackDamage;
        }
    }
}
