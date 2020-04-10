using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    Controller ct;
    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        ct = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ct.CurrentTool == gameObject.GetComponent<MoveTarget>())
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "petri")
                    {
                        target.position = hit.point + offset;
                    }
                }
            }
        }  
    }

}
