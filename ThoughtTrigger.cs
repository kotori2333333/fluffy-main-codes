using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtTrigger : MonoBehaviour
{
    public bool activated = false;

    public bool correctFruit = false;



    public bool bubbleAct = false;
    public bool appleAct = false;
    public bool bananaAct = false;
    public bool berryAct = false;

    public GameObject bubble;
    public GameObject apple;
    public GameObject banana;
    public GameObject berry;

    private SpriteRenderer bubbleR;
    private SpriteRenderer appleR;
    private SpriteRenderer bananaR;
    private SpriteRenderer berryR;

    public float bubbleA = 0f;
    public float appleA = 0f;
    public float bananaA = 0f;
    public float berryA = 0f;

    private Coroutine bubbleH;
    private Coroutine appleH;
    private Coroutine bananaH;
    private Coroutine berryH;

    public int thoughtIndex;
    public static int currentIndex;

    

    void Start()
    {
        bubbleR = bubble.GetComponent<SpriteRenderer>();
        appleR = apple.GetComponent<SpriteRenderer>();
        bananaR = banana.GetComponent<SpriteRenderer>();
        berryR = berry.GetComponent<SpriteRenderer>();

        bubbleR.color = new Color(1, 1, 1, 0);
        appleR.color = new Color(1, 1, 1, 0);
        bananaR.color = new Color(1, 1, 1, 0);
        berryR.color = new Color(1, 1, 1, 0);
    }



    void Update()
    {

        if (bubbleAct)
        {
            if(thoughtIndex == currentIndex && currentIndex != 0 && thoughtIndex != 0)
            {
                correctFruit = true;
                TutorialManager.stayDuration += 20;
                currentIndex = 0;
            }

        }


        /*
        if (activated)
        {
            if (!bubbleAct)
            {
                StartCoroutine(bubbleShow(bubbleR, bubbleA, bubbleH));
                int randFruit = Random.Range(0, 3);
                switch (randFruit)
                {
                    case 0:
                        StartCoroutine(bubbleShow(appleR, appleA, appleH));
                        break;
                    case 1:
                        StartCoroutine(bubbleShow(bananaR, bananaA, bananaH));
                        break;
                    case 2:
                        StartCoroutine(bubbleShow(berryR, berryA, berryH));
                        break;
                }

            }



        }

        */
    }



    IEnumerator bubbleShow(SpriteRenderer renderer, float alpha, Coroutine hide)
    {
        bubbleAct = true;
        yield return new WaitForSeconds(1.0f);
        while (alpha < 1)
        {
            alpha += 0.01f;
            renderer.color = new Color(1, 1, 1, alpha);

            if (correctFruit)
            {
                StartCoroutine(bubbleHide(renderer, alpha));
                correctFruit = false;
                yield break;
            }

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(bubbleWait(renderer, alpha, hide));

    }

    IEnumerator bubbleWait(SpriteRenderer renderer, float alpha, Coroutine hide)
    {
        int counter = 0;

        while (counter < 50)
        {
            yield return new WaitForSeconds(0.1f);
            if (correctFruit)
            {
                StartCoroutine(bubbleHide(renderer, alpha));
                correctFruit = false;
                yield break;
            }
            counter += 1;
        }

        //yield return new WaitForSeconds(5.0f);

        hide = StartCoroutine(bubbleHide(renderer, alpha));


    }


    IEnumerator bubbleHide(SpriteRenderer renderer, float alpha)
    {
        while (alpha > 0)
        {
            alpha -= 0.01f;
            renderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0.01f);
        }

        thoughtIndex = 0;
        currentIndex = 0;
    }

    //show bubble and random fruit - fast fade in
    //slow fade in fruit

    public void fruitTrigger()
    {
        StartCoroutine(bubbleShow(bubbleR, bubbleA, bubbleH));
        int randFruit = Random.Range(0, 3);
        switch (randFruit)
        {
            case 0:
                StartCoroutine(bubbleShow(appleR, appleA, appleH));
                thoughtIndex = 1;
                break;
            case 1:
                StartCoroutine(bubbleShow(bananaR, bananaA, bananaH));
                thoughtIndex = 2;

                break;
            case 2:
                StartCoroutine(bubbleShow(berryR, berryA, berryH));
                thoughtIndex = 3;
                break;
        }


    }

}
