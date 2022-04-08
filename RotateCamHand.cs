using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamHand : MonoBehaviour
{
    public float turnSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
    }
}
