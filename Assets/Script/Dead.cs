using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject me;
    public GameObject coin;
    private GameObject score;
    private AbilityScript ability;
    private SpeedUp speed;

    public int maxCoin;
    public float time;
    private void Start()
    {
        ability = me.GetComponent<AbilityScript>();
        score = GameObject.Find("Score");
        speed = score.GetComponent<SpeedUp>();
    }
    private void Update()
    {
        if (ability.hp <= 0)
            StartCoroutine(isDead());
    }
    IEnumerator isDead()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 115);
        gameObject.layer = 8;
        yield return new WaitForSeconds(time);
        for (int i = 0; i < Random.Range(1, (maxCoin + 1) * (speed.level * 1.25f)); i++)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
        score.GetComponent<TextUpdate>().data += 6;
        Destroy(this.gameObject);
    }
}
