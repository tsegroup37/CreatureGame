using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFood : MonoBehaviour
{
    Controller ct;
    public GameObject food;
    public int maxCount;
    private List<food> totalPlaced = new List<food>();
    int time;
    float clock;

    void Start()
    {
        ct = FindObjectOfType<Controller>();
    }

    void Update()
    {
        clock += Time.deltaTime;
        time = (int)clock;

        foreach (var component in FindObjectsOfType<food>())
        {
            if (!totalPlaced.Contains(component))
            {
                totalPlaced.Add(component);
            } 
        }



        if (ct.CurrentTool == gameObject.GetComponent<PlaceFood>() && totalPlaced.Count < maxCount && clock > 5)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "petri")
                    {
                        GameObject foodObj = (GameObject)Instantiate(food, hit.point, hit.transform.rotation);
                        clock = 0;
                    }
                }
            }
        }
        else
        {
            Debug.Log("Max amount of food");
        }
    }
}
