using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public float currentScale = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        currentScale = TutorialManager.stayDuration.Remap(0, 70, 0, 1)+0f;
        transform.localScale = new Vector3(0.0369f, currentScale, 0.0369f);
    }
}


public static class ExtensionMethods
{

    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

}