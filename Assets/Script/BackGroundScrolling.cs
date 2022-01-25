using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    private MeshRenderer render;
    private float offset = 0.0f;
    public float speed = 0.0f;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        offset += speed * Time.deltaTime;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
