using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool started = false;
    public bool activated = true;
    public GameObject thing;

    private float interval = 9f;
    public float intervalLow = 9f;
    public float intervalHigh = 15f;

    void Start()
    {
        
    }

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
            Instantiate(thing, transform.position, Quaternion.identity);
            interval = Random.Range(intervalLow, intervalHigh);
            yield return new WaitForSeconds(interval);
        }
    }
}
