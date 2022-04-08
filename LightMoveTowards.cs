using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoveTowards : MonoBehaviour
{
    //public GameObject me;
    public GameObject[] targets;
    private GameObject target;
    public float speed = 1f;

    public float TimeToLive = 2f;
    private Rigidbody rb;
    public Animator anim;

    private bool hitted = false;

    private bool animPlayed = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targets = GameObject.FindGameObjectsWithTag("MonsterT");
        target = targets[0];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Hand")
        {
            rb.useGravity = true;
            Destroy(gameObject);
            Destroy(this);

        }

        if (collision.gameObject.tag == "Monster" && !hitted)
        {
            //TutorialManager.stayDuration -= 10;
            hitted = true;
            Destroy(gameObject, 1f);

        }
    }

}