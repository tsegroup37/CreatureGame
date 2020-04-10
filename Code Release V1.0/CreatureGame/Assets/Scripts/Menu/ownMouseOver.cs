using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ownMouseOver : MonoBehaviour
{

    public Camera cam;

    public float sens;

    private Vector3 defaultPos;

    private Vector3 midPoint;

    private bool enter;

    private bool exit;



    // Start is called before the first frame update
    void Start()
    {
        defaultPos = cam.transform.position;
        midPoint = (transform.position + cam.transform.position) / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(enter)
        {
            cam.transform.LookAt(cam.WorldToScreenPoint(transform.position));
            cam.transform.position = Vector3.Slerp(cam.transform.position, midPoint, sens);
        }
        if(exit)
        {
            cam.transform.position = Vector3.Slerp( cam.transform.position, defaultPos, sens);
        }
    }
    private void OnMouseEnter()
    {
       
        enter = true;
        exit = false;

    }
    private void OnMouseExit()
    {
        
        enter = false;
        exit = true;
    }
    public void SetActive(bool active)
    {
        if(active)
        {
            enabled = true;
        }
    }
}
