using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityComingScript : MonoBehaviour
{
    private float speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
    }
}
