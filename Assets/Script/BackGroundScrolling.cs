using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    private MeshRenderer render;
    private EntityComingScript entityComing;
    private AbilityScript ability;
    private float offset = 0.0f;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        ability = GetComponent<AbilityScript>();
    }
    void Update()
    {  
        offset += ability.moveSpeed * Time.deltaTime;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
