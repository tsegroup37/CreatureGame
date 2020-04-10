using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Camera cam;
    public float speed = 10.0f;
    float rotX;
    float rotY;
    float RotSpeed = 2;
    float UpDown;
    float LeftRight;
    public float rotationSpeed = 100.0f;
    public Transform target;

    public GameObject campos;

    int index = 0;
    public Vector3[] zoomLevel;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()   
    {

        campos.transform.position = zoomLevel[index];

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            index++;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            index--;
        }
        if(index > 2)
        {
            index = 2;
        }
        if(index < 0)
        {
            index = 0;
        }

    }

}
