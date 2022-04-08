using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    public Animator monsterAnim;
    AnimatorClipInfo[] animatorinfo;
    string current_animation;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            monsterAnim.SetTrigger("loveout");
            monsterAnim.SetTrigger("angryout");

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Comfort")
        {
            monsterAnim.SetTrigger("loveout");
        }

        if (other.gameObject.tag == "Spike")
        {
            monsterAnim.SetTrigger("angryout");
        }
    }

    void OnTriggerStay(Collider other)
    {
        animatorinfo = monsterAnim.GetCurrentAnimatorClipInfo(0);
        current_animation = animatorinfo[0].clip.name;

        if (Input.GetMouseButton(0))
        {
            if (other.gameObject.tag == "Comfort")
            {
                TutorialManager.stayDuration += 0.01f;
                Febucci.UI.Examples.InitTutorialManager.petted = true;

                //Debug.Log(current_animation);

                if (current_animation == "idle")
                {

                    monsterAnim.Play("lovein");

                }
            }

            if (other.gameObject.tag == "Spike")
            {
                Debug.Log(11);
                TutorialManager.stayDuration -= 0.005f;

                if (current_animation == "idle")
                {
                    monsterAnim.Play("angryin");
                }
            }
        }
    }
}
