using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //manage tutorial sequence
    public ThoughtTrigger fruit;

    public bool handMoved = false;
    public bool handRotated = false;


    public bool zonePetted = false;
    public bool longEnough = false;
    public bool flyGenerate = false;
    public bool slapFly = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            fruit.fruitTrigger();
        }    
    }

   

}
