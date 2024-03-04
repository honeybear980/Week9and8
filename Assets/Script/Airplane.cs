using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public Rigidbody rb;
    public float enginPowerThrust, liftBooster, drag, angularDrag;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginPowerThrust);
        }

        Vector3 lift = Vector3.Project(rb.velocity, transform.forward); 
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.drag = rb.velocity.magnitude * drag;
        rb.angularDrag = rb.velocity.magnitude * angularDrag;
        
        rb.AddTorque(Input.GetAxis("Horizontal") * transform.forward * -1);
        
        rb.AddTorque(Input.GetAxis("Vertical") * transform.right);
    }
}
