using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Transform cam;
    public Transform guntip;
    public LayerMask whatIsGrappleable;
    public LineRenderer grappleline;

    public float maxGrappleDistance;
    public float grappleDelayTime;

    private Vector3 grapplePoint;

    public float grappleCD;
    private float grappleCDTimer;

    [SerializeField] public KeyCode grappleKey = KeyCode.Mouse0;

    private bool grappling;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(grappleKey)) StartGrapple();

        if (grappleCDTimer > 0)
            grappleCDTimer -= Time.deltaTime;
    }

    private void StartGrapple()
    {
        if (grappleCD > 0) return;

        grappling = true;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
        }
        else
        {
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;

            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
        }



    }
    private void ExecuteGrapple()
    {

    }
    private void StopGrapple()
    {
        grappling = false;

        grappleCDTimer = grappleCD;
    }
}
