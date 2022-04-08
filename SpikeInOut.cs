using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeInOut : MonoBehaviour
{
    public float originalZ;
    public float newZ;
    public Vector3 distance = new Vector3(0,0,0.2f);
    public float speed = 0.06f;

    public int stage; 

    public Vector3 origin;
    public Vector3 dest;

    public float w1 = 2f;
    public float w2 = 2f;
    public float w3 = 2f;
    public float w4 = 2f;
    void Start()
    {
        origin = transform.localPosition;
        dest = origin + distance;

        StartCoroutine(Pattern());
    }

    // Update is called once per frame
    void Update()
    {

        if(stage == 1)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, dest, speed);
        }

        else if(stage == 3)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, origin, speed);

        }
    }

    IEnumerator Pattern()
    {
        yield return new WaitForSeconds(w1);
        stage = 1;
        yield return new WaitForSeconds(w2);
        stage = 2;
        yield return new WaitForSeconds(w3);
        stage = 3;
        yield return new WaitForSeconds(w4);
        stage = 0;
        StartCoroutine(Pattern());


    }
}
