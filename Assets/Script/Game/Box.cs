using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject[] Iteam;
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Iteam[Random.Range(0, Iteam.Length)]);
    }
}
