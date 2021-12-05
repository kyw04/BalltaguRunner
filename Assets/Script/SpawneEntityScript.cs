using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneEntityScript : MonoBehaviour
{
    public GameObject balltagu;
    public GameObject entity;
    public float spawningTime = 5.0f;
    private bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        balltagu = GameObject.Find("Balltagu");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = balltagu.transform.position + new Vector3(48f, 0, 0);
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
