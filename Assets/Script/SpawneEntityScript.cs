using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawneEntityScript : MonoBehaviour
{
    public GameObject balltagu;
    public GameObject entity;
    public float spawningTime = 5.0f;
    public float distance;
    private bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        balltagu = GameObject.Find("Balltagu");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(balltagu.transform.position.x + distance, gameObject.transform.position.y, gameObject.transform.position.z); // x 위치만 변경.
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
