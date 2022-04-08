using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInOut : MonoBehaviour
{
    public float sensitivity = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition -= new Vector3(0f, 0f, sensitivity);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += new Vector3(0f, 0f, sensitivity);
        }

        
    }
}
