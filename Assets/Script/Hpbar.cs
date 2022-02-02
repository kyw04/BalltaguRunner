using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public Image hpbar;
    private AbilityScript ability;

    // Start is called before the first frame update
    void Start()
    {
        ability = GetComponent<AbilityScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
