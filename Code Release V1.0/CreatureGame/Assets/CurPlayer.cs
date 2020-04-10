using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurPlayer : MonoBehaviour
{
    public GameManager GameManager;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentPlayer == null)
        {
            Destroy(gameObject);
        }
        else
        transform.position = GameManager.CurrentPlayer.transform.position + offset;

        
    }
}
