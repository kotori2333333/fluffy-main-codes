using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject thought;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Thought());
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.U))
        {
            thought.GetComponent<ThoughtTrigger>().fruitTrigger();
        }
    }


    IEnumerator Thought()
    {
        yield return new WaitForSeconds(Random.Range(8,10));
        thought.GetComponent<ThoughtTrigger>().fruitTrigger();
        yield return new WaitForSeconds(Random.Range(15,20));
    }
}
