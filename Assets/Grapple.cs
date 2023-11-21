using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public GameObject grapplePoint;
    public GameObject grappleBuddy;

    public float maxGrappledistance = 20f;
    public float distanceBetweenObjects;
    public LayerMask GrapplePoint;
    public bool isGrappled;

    public LineRenderer grapple;


    public float GrappleCD;
    public float grappleDelayTimer;

    public void Update()
    {
        Debug.DrawRay(grappleBuddy.transform.position, grapplePoint.transform.position - grappleBuddy.transform.position, Color.blue); 
        if (Input.GetKeyDown(KeyCode.E))
        {

            distanceBetweenObjects = Vector3.Distance(grapplePoint.transform.position, grappleBuddy.transform.position);

            print(distanceBetweenObjects);



            RaycastHit hit;

            if (Physics.Raycast(grappleBuddy.transform.position, grapplePoint.transform.position - grappleBuddy.transform.position, out hit, maxGrappledistance, GrapplePoint))
            {
                Debug.DrawRay(grappleBuddy.transform.position, grapplePoint.transform.position - grappleBuddy.transform.position,Color.red);
                Debug.Log("Did Hit");
                grapple.SetPosition(0, grappleBuddy.transform.position);
                grapple.SetPosition(1, grapplePoint.transform.position);
            }
            else
            {

                Debug.Log("Did not Hit");
            }
        }
    }

    public void Startgrapple()
    {

    }
     public void Executegrapple()
    {

    }
    public void Exitgrapple()
    {

    }



}

    