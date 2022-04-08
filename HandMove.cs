using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
 private Vector3 _startPosition;
 public float frequency = 10;
 public float amplitude = 40; 


 void Start () 
 {
     _startPosition = transform.localPosition;
    
 }
 
 void Update()
 {
        if (Input.GetMouseButton(0))
        {
            transform.localPosition = _startPosition + new Vector3(Mathf.Sin(Time.time * frequency ) / amplitude, 0.0f, 0.0f);
        }
        else
        {
            transform.localPosition = new Vector3(0,-0.055f,0);
        }

    }
}
