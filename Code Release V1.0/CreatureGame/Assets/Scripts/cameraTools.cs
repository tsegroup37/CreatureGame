using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTools : MonoBehaviour
{
    public Camera cam;
    public Vector3 offset;
    GameManager gm;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();      
    }


    void LateUpdate()
    {

        player = gm.CurrentPlayer;

        cam.transform.LookAt(player.transform);
        cam.transform.position = player.transform.position + offset;
    }
}
