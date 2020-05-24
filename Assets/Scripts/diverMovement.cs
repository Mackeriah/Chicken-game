using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diverMovement : MonoBehaviour
{
    public Rigidbody ourRigidBody;

    public float forwardForce = 2000f;
    public float sidewaysForce = 2000f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            ourRigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            ourRigidBody.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            ourRigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            ourRigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }

    }
}
