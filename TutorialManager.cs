using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static float stayDuration = 0;
    public static float maxDuration = 150;
    public int lengthToPlay = 15;
    public int lengthCounter = 1;
    public Animator monsterAnim;
    public bool played = false;
    AnimatorClipInfo[] animatorinfo;
    string current_animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animatorinfo = monsterAnim.GetCurrentAnimatorClipInfo(0);
        current_animation = animatorinfo[0].clip.name;

        Debug.Log(stayDuration);
        if(stayDuration > maxDuration / 2)
        {
            Febucci.UI.Examples.InitTutorialManager.petEnough = true;
        }

        if (stayDuration >= maxDuration)
        {
            Febucci.UI.Examples.InitTutorialManager.petMaxed = true;
            if (current_animation == "idle")
            {
                monsterAnim.Play("LoveAni");
            }
        }

        if(stayDuration > maxDuration)
        {
            stayDuration = maxDuration;
        }

        if (stayDuration>lengthToPlay*lengthCounter && (int)stayDuration !=0 && !played){


            if (current_animation == "idle")
            {
                monsterAnim.Play("LoveAni");
                played = true;
                lengthCounter += 1;
            }
        }
        if (stayDuration==lengthToPlay*lengthCounter+1)
        {
            played = false;
        }

    }
}
