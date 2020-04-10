using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObstacles : MonoBehaviour
{
    Controller ct;
    [SerializeField]
    private int maxObstacles = 5;

    public GameObject[] obstacles;
    private List<GameObject> totalPlaced = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        ct = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ct.CurrentTool == gameObject.GetComponent<PlaceObstacles>())
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "petri")
                    {
                        GameObject obstacle = (GameObject)Instantiate(obstacles[Random.Range(0,obstacles.Length)], hit.point, hit.transform.rotation);
                        Place(obstacle);
                    }
                }
            }
        }
    }

    void Place(GameObject obstacle)
    {
        totalPlaced.Add(obstacle);
        if(totalPlaced.Count > maxObstacles)
        {
            Object.Destroy(totalPlaced[0].gameObject);
            totalPlaced.RemoveAt(0);
        }
    }
}
