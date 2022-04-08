using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAttach : MonoBehaviour
{
    public bool activated = true;
    private GameObject hand;
    public float yOff = 0.3f;
    public float xOff = -0.1f;

    public int fruitIndex = 0; // apple 1; banana 2; berry 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

            if (other.gameObject.tag == "Hand")
            {
                if (Input.GetMouseButton(0))
                {
                    hand = other.gameObject;
                    StartCoroutine(Generate());
                }

            }
        

            if(other.gameObject.tag == "Monster")
            {
                ThoughtTrigger.currentIndex = fruitIndex;
                Destroy(gameObject);
            }

    }

    IEnumerator Generate()
    {
        if (activated)
        {
            activated = false;
            var newFruit = Instantiate(gameObject, new Vector3(transform.position.x+xOff, transform.position.y+yOff, transform.position.z), Quaternion.identity);
            newFruit.transform.parent = hand.transform;
            yield return new WaitForSeconds(3);
            activated = true;

        }



    }

}

