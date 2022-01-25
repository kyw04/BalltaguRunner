using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public bool stop = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
            transform.position += new Vector3(speed, default, default) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stop")
            stop = true;
    }
}
