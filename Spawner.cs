using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spots;
    public GameObject thing;

    public float xRange = 12f;
    public float zRange = 12f;

    private float interval = 4f;
    public float intervalLow = 4f;
    public float intervalHigh = 6f;

    public bool activated = true;

    private Transform pos;

    private bool started = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Febucci.UI.Examples.InitTutorialManager.flySpawn || activated) && !started)
        {
            StartCoroutine("DoCheck");
            started = true;
        }
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        { 
            pos = spots[Random.Range(0,2)];
            pos.position = new Vector3(pos.transform.position.x + Random.Range(-xRange, xRange), pos.transform.position.y, pos.transform.position.z + Random.Range(-zRange,zRange));
            Instantiate(thing, pos.position, Quaternion.identity);
            interval = Random.Range(intervalLow, intervalHigh);
            yield return new WaitForSeconds(interval);
         }
    }
}
