using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public GameObject me;
    private GameObject score;
    private GameObject money;
    private AbilityScript ability;

    public float time;
    private void Start()
    {
        ability = me.GetComponent<AbilityScript>();
        score = GameObject.Find("Score");
        money = GameObject.Find("Money");
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
        score.GetComponent<TextUpdate>().data += 6;
        money.GetComponent<TextUpdate>().data += 6;
        Destroy(this.gameObject);
    }
}
