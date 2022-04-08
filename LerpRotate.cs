using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpRotate : MonoBehaviour
{
    [SerializeField] [Range(0f, 3f)] float lerpTime;
    [SerializeField] [Range(0f, 3f)] float interval;
    float t = 0f;
    Vector3 randVector;

    void Start()
    {
        randVector = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(randVector), lerpTime * Time.deltaTime);
        t = Mathf.Lerp(t, interval, lerpTime * Time.deltaTime);
        if (t >= interval-0.1f)
        {
            t = 0f;
            randVector = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
        }
    }
}
