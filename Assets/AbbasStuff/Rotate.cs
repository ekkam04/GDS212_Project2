using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 spin;
    public float speed = 1f;

    public void Update()
    {
       transform.Rotate(spin * speed * Time.deltaTime);
    }

}
