using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneEntityScript : MonoBehaviour
{
    public GameObject entity;
    public float spawningTime = 5.0f;
    private bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnEntity());
        }
    }

    IEnumerator SpawnEntity()
    {
        GameObject newEntity = Instantiate(entity);
        newEntity.transform.position = this.transform.position;
        yield return new WaitForSeconds(spawningTime);
        isSpawning = false;
    }
}
