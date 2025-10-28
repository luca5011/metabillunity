using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class RouletteControl : MonoBehaviour
{
    public float rotspead = 0.0f;

    void Start()
    {
            
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            rotspead += 10.0f;
        }
        rotspead *= 0.995f;
        
        this.gameObject.transform.Rotate(0, 0, rotspead);

        
    }
}
        