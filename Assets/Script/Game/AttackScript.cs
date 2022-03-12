using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private GameObject player;
    private BalltaguScript balltaguScript;
    private AbilityScript playerAbility;
    private AbilityScript collisionAbility;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Balltagu");
        balltaguScript = player.GetComponent<BalltaguScript>();
        playerAbility = player.GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(1, 0, 0);

        if (balltaguScript.Dashing)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionAbility = collision.GetComponent<AbilityScript>();
        if (collision.gameObject.tag == "Monster")
        {
            collisionAbility.hp -= playerAbility.attackDamage;
            Sound.instance.PlaySound(0);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(750, 500));
        }
        if (collision.gameObject.tag == "Box")
        {
            collisionAbility.hp -= playerAbility.attackDamage;
        }
    }
}
