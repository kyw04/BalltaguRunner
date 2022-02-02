using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    private TextUpdate money;
    private bool touchFloor;
    public float speed;
    private float dir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Balltagu");
        money = GameObject.Find("Money").GetComponent<TextUpdate>();
        touchFloor = false;
        dir = 1;
        float randX = Random.Range(-5.5f, 5.5f);
        float randY = Random.Range(0, 5.5f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(randX, randY), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (touchFloor)
        {
            Vector2 direct = player.transform.position - transform.position;
            GetComponent<Rigidbody2D>().AddForce(speed * (direct * dir), ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            touchFloor = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            money.data += 1;
        }
    }
}
