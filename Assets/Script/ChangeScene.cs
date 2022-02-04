using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public GameObject SceneTransition;
    public Image MainSceneTransition;
    public bool TransitionEnd = true;

    private void Start()
    {
        TransitionEnd = true;
    }
    public void SceneChange()
    {
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        GameObject button = GameObject.Find(button_name);
        Index index = button.GetComponent<Index>();
        SceneManager.LoadScene(index.value);
    }

    public void StartScene()
    {
        if (TransitionEnd == true)
        {
            TransitionEnd = false;
            StartCoroutine(Transition(1, 0));
        }
    }
    public void EndScene(int index)
    {
        if (TransitionEnd == true)
        {
            TransitionEnd = false;
            StartCoroutine(Transition(-1, index));
        }
    }

    IEnumerator Transition(int value, int index)
    {
        int num;
        SceneTransition.SetActive(true);
        if (value == 1)
        {
            Debug.Log("0");
            num = 0;
            MainSceneTransition.fillAmount = 1;
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            Debug.Log("1");
            num = 1;
            MainSceneTransition.fillAmount = 0;
        }
        while (MainSceneTransition.fillAmount != num)
        {
            yield return new WaitForSeconds(0.0001f);
            MainSceneTransition.fillAmount += -value * 0.025f;
        }
        TransitionEnd = true;

        if (value == -1)
            SceneManager.LoadScene(index);
    }
}
