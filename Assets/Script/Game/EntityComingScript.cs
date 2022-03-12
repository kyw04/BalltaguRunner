using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityComingScript : MonoBehaviour
{
    private AbilityScript ability;
    // Start is called before the first frame update
    void Start()
    {
       ability = GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(-ability.moveSpeed, 0, 0) * Time.deltaTime;
    }
}
