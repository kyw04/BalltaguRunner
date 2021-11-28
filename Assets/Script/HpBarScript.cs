using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour
{
    GameObject player;
    AbilityScript ability;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Balltagu");
        ability = player.GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().fillAmount = ability.hp / (float)ability.maxHp; ;
    }
}
