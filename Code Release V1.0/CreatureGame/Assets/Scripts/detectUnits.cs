using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectUnits : MonoBehaviour
{
    public LayerMask test;
    public Collider[] hitColliders;
    public Vector3 offset;
    public OrganismBrain OB;
    public float dist;
    public Transform one;
        public Transform two;
        public Transform three;
    public Transform right;

    public int wheretogo;


    bool rightDir;
    bool leftDir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(one.position, transform.TransformDirection(Vector3.forward), out hit, dist) || Physics.Raycast(two.position, transform.TransformDirection(Vector3.forward), out hit, dist) || Physics.Raycast(three.position, transform.TransformDirection(Vector3.forward), out hit, dist))
        {
            OB.defaultMovement = false;
            Debug.DrawRay(one.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.DrawRay(two.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.DrawRay(three.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Something In Front");
            //move left or right

            //OB.move(OB.target, Vector3.forward);
            //OB.move2(transform.right, Vector3.forward);
            transform.LookAt(hit.point);
            wheretogo = directionsAvailable();
            Debug.Log(wheretogo);
            switch(wheretogo)
            {
                case 1:
                    OB.rb.AddRelativeForce(Vector3.right * 20);
                   // OB.move2(hit.point, Vector3.forward);
                    return;
                case 2:
                    OB.rb.AddRelativeForce(Vector3.left * 20);
                    //OB.move2(hit.point, Vector3.back);
                    return;
                case 0:
                  
                    return;
            }
        }
        else
        {
          OB.defaultMovement = true;
        }
    }
    int directionsAvailable()
    {
        RaycastHit hitA;
        RaycastHit hitB;
        int directions = 0;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hitA, dist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hitA.distance, Color.yellow);
            Debug.Log("Something To right");
        }
        else
        {
            directions += 1;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hitB, dist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hitB.distance, Color.yellow);
            Debug.Log("Something To left");
        }
        else
        {
            directions += 2;
        }

        if(directions == 3)
        {
            directions = findNearestDir();
        }

        return directions;
    }
    int findNearestDir()
    {
        int direction = 3;
        float leftPos = Vector3.Distance((transform.position + offset), OB.target.transform.position);
        float rightPos = Vector3.Distance((transform.position - offset), OB.target.transform.position);
        if (leftPos < rightPos)
            direction = 2;
        else
            direction = 1;


        return direction;
    }
}
