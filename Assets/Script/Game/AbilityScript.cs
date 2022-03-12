using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScript : MonoBehaviour
{
    public int maxHp = 10;
    public int hp = 10;
    public int attackDamage = 1;
    public float moveSpeed = 2.5f;
    public float jumpPower = 500.0f;
    public float attackSpeed = 0.5f;
    public float attackDestroyTime = 0.25f;

    private void Update()
    {
        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
}
