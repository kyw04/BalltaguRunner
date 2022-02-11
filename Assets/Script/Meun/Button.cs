using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject stop;
    public GameObject[] gameObjects;
    private GameObject balltagu;
    private Move move;
    void Start()
    {
        Close();
        balltagu = GameObject.Find("Balltagu");
        move = balltagu.GetComponent<Move>();
    }

    void Update()
    {
        
    }

    public void Close()
    {
        Time.timeScale = 1;
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

    public void StartButtonClick()
    {
        StartCoroutine(StartGame());
    }

    public void SettingButtonClick()
    {
        gameObjects[0].SetActive(true);
    }

    IEnumerator StartGame()
    {
        Destroy(stop);
        move.stop = false;
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("EventSystem").GetComponent<ChangeScene>().EndScene(1);
    }

}
