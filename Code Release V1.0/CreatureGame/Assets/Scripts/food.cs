using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    private GameManager gm;
    public float foodAmount;


    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.addFood(gameObject);
        foodAmount = Random.Range(25, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (foodAmount <= 0)
        {
            gm.removeFood(gameObject);
            Destroy(gameObject);
            
        }
    }
 
}
