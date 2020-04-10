using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool go;


    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            transform.Rotate(transform.position, -2f);
        }
        
    }
}
