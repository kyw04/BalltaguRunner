using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    private MeshRenderer render;
    private float offset = 0.0f;
    public float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += speed * Time.deltaTime;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
