using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private GameObject player;
    private TextUpdate score;
    private AbilityScript ability;
    private float nextScore;
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Balltagu");
        nextScore = 100;
        score = GameObject.Find("Score").GetComponent<TextUpdate>();
        ability = GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score.data >= nextScore)
        {
            SpeedUp speed = GameObject.Find("Score").GetComponent<SpeedUp>();
            nextScore *= 2.5f;
            Debug.Log(nextScore);
            if (ability != null) { ability.moveSpeed *= 1.15f; }
            if (this.gameObject.name == "Score") { level += 1; }
            if (player != null) { player.GetComponent<Rigidbody2D>().mass = 1 + (speed.level * 0.01f); }
            player.GetComponent<Animator>().SetFloat("walkSpeed", 1 + speed.level * 0.1f);
        }
    }
}
