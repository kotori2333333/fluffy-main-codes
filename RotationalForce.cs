using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalForce : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = rb.velocity.magnitude;
        angularSpeed = rb.angularVelocity.magnitude;
        rb.AddTorque(Vector3.forward);

    }
}
