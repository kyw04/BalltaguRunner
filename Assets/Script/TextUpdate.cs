using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    public GameObject player;
    public Text text;
    private SpeedUp speed;
    public int data;
    public float time;
    public string text_data;
    public bool data_add;
    private string start_data;
    private bool text_update;
    // Start is called before the first frame update
    void Start()
    {
        data = 0;
        text_update = true;
        start_data = text_data;
        speed = GetComponent<SpeedUp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text_update && player.GetComponent<AbilityScript>().hp > 0 && data_add)
            StartCoroutine(update());
        text_data = start_data + data;
        text.text = text_data;
    }

    IEnumerator update()
    {
        text_update = false;
        time =  1 / speed.level + 1;
        yield return new WaitForSeconds(time);
        text_update = true;
        data += 1;
    }
}
