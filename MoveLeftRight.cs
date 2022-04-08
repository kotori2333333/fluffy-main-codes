using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    

    public float speed;
    public float offset;
    public float interval;
    Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, 1) * interval - offset;
        //transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z);
        transform.position = origin + new Vector3(x, 0, 0);

    }
}
