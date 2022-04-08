using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    Vector3 startPosition;
    Rigidbody rb;
    public Transform handPos;
    public bool onHand = false;
    public int stayCounter = 0;
    public int stayCap = 400;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onHand)
        {
            transform.position = handPos.position;
        }

        if(stayCounter > stayCap)
        {
            Febucci.UI.Examples.InitTutorialManager.stampEnough = true;
            ContractSprite.change = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hand")
        {

            Febucci.UI.Examples.InitTutorialManager.stampReached = true;
            if (Input.GetMouseButton(0))
            {
                
                Febucci.UI.Examples.InitTutorialManager.stampOnHand = true;

                onHand = true;
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Contract")
        {
            if (Input.GetMouseButton(0))
            {
                Febucci.UI.Examples.InitTutorialManager.stampStart = true;

                stayCounter += 1;

            }
        }
    }
}
