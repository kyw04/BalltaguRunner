using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    GameObject player;
    AbilityScript ability;

    public Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Balltagu");
        ability = player.GetComponent<AbilityScript>();
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < ability.hp)
            {
                hearts[i].gameObject.GetComponent<Animator>().SetBool("isErased", false);
                hearts[i].enabled = true;
            }
            else
            {
                StartCoroutine(erased_heart(hearts[i]));
               
            }
        }
    }
    IEnumerator erased_heart(Image heart)
    {
        heart.gameObject.GetComponent<Animator>().Play("hp_erased");
        heart.gameObject.GetComponent<Animator>().SetBool("isErased", true);
        yield return new WaitForSeconds(0.5f);
        heart.enabled = false;
    }
}
