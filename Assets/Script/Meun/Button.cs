using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject stop;
    private GameObject balltagu;
    private Move move;
    void Start()
    {
        balltagu = GameObject.Find("Balltagu");
        move = balltagu.GetComponent<Move>();
    }

    void Update()
    {
        
    }

    public void StartButtonClick()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Destroy(stop);
        move.stop = false;
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("EventSystem").GetComponent<ChangeScene>().EndScene(1);
    }

}
