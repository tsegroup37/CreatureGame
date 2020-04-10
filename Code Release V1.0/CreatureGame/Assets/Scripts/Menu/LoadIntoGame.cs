using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadIntoGame : MonoBehaviour
{
    public bool start;
    private Camera cam;
    public Transform camDestination;
    public float sens;

    public Transform petriLocation;

    public List<ownMouseOver> objects;
    // Start is called before the first frame update

    private void Start()
    {
        cam = Camera.main;
        
    }
    private void FixedUpdate()
    {
     
        foreach (var component in FindObjectsOfType<ownMouseOver>())
        {
            if (!objects.Contains(component))
            {
                objects.Add(component);
            }
            
        }


        if (start)
        {
            foreach (ownMouseOver obj in objects)
            {
                obj.enabled = false;
            }

            FindObjectOfType<lookAtMouse>().enabled = false;
            cam.transform.position = Vector3.Lerp(cam.transform.position, camDestination.position, sens);
            cam.transform.LookAt(petriLocation.position);
            
            if(cam.transform.position.x == camDestination.transform.position.x)
            {
                enabled = false;
                Debug.Log("test");
            }
        }
    }
    private void OnMouseDown()
    {
        start = true;
    }
}
