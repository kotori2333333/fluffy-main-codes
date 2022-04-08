using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thoughts : MonoBehaviour
{
    public GameObject bubble;
    public GameObject apple;
    public GameObject banana;
    public GameObject berry;

    private SpriteRenderer bubbleR;
    private SpriteRenderer appleR;
    private SpriteRenderer bananaR;
    private SpriteRenderer berryR;

    public float bubbleA;
    public float appleA;
    public float bananaA;
    public float berryA;


    public int counter;
    public float waitTime;
    public int fruit;
    public float opacity;

    public float appearSpeed = 0.05f;

    void Start()
    {
        bubbleR = bubble.GetComponent<SpriteRenderer>();
        appleR = apple.GetComponent<SpriteRenderer>();
        bananaR = banana.GetComponent<SpriteRenderer>();
        berryR = berry.GetComponent<SpriteRenderer>();

        bubbleR.color = new Color (1,1,1,0);
        appleR.color = new Color(1, 1, 1, 0);
        bananaR.color = new Color(1, 1, 1, 0);
        berryR.color = new Color(1, 1, 1, 0);

        bubbleA = 0;
        appleA = 0;
        bananaA = 0;
        berryA = 0;

        //StartCoroutine("Change");
        //StartCoroutine("PeriodChange");

    }

    // Update is called once per frame
    void Update()
    {
        ShowBerry();
    }

    public void ShowBerry()
    {
        if(bubbleR.color.a < 1)
        {
            bubbleA += appearSpeed;
            bubbleR.color = new Color(1, 1, 1, bubbleA);

            if (bubbleR.color.a == (1 - appearSpeed))
            {
                Invoke("HideBerry",5f);
            }

        }

    }

    public void HideBerry()
    {
        if (bubbleR.color.a > 0)
        {
            bubbleA -= appearSpeed;
            bubbleR.color = new Color(1, 1, 1, bubbleA);
        }
    }



    IEnumerator PeriodChange()
    {
        for (; ; )
        {
            bubble.GetComponent<Renderer>().enabled = true;

            fruit = Random.Range(1, 4);
            switch (fruit)
            {
                case 1:
                    bananaR.enabled = false;
                    berryR.enabled = false;
                    appleR.enabled = true;
                    break;
                case 2:
                    apple.GetComponent<Renderer>().enabled = false;
                    berry.GetComponent<Renderer>().enabled = false;
                    banana.GetComponent<Renderer>().enabled = true;
                    break;
                case 3:            
                    apple.GetComponent<Renderer>().enabled = false;
                    banana.GetComponent<Renderer>().enabled = false;
                    berry.GetComponent<Renderer>().enabled = true;
                    break;
            }

            waitTime = Random.Range(2, 4);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator Change()
    {
        for (; ; )
        {
            if (Mod(counter, 3) == 0)
            {
                banana.GetComponent<Renderer>().enabled = false;
                berry.GetComponent<Renderer>().enabled = false;
                apple.GetComponent<Renderer>().enabled = true;

            }
            else if (Mod(counter, 3) == 1)
            {
                apple.GetComponent<Renderer>().enabled = false;
                berry.GetComponent<Renderer>().enabled = false;
                banana.GetComponent<Renderer>().enabled = true;

            }
            else if (Mod(counter, 3) == 2)
            {
                apple.GetComponent<Renderer>().enabled = false;
                banana.GetComponent<Renderer>().enabled = false;
                berry.GetComponent<Renderer>().enabled = true;
            }

            counter += 1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    int Mod(int a, int b)
    {
        return (a % b + b) % b;
    }

}
