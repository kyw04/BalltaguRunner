using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RongEyeScript : MonoBehaviour
{
    public GameObject rong;
    private RongScript rongScript;
    // Start is called before the first frame update
    void Start()
    {
        rongScript = rong.GetComponent<RongScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rongScript.isPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rongScript.isPlayer = false;
        }
    }
}
