using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveControl : MonoBehaviour
{
    public float height = 0f;
    public float maxHeight = 6.52f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        height = ExtensionMethods.Remap(TutorialManager.stayDuration, 0, TutorialManager.maxDuration, 1, maxHeight);

        GetComponent<RectTransform>().localScale = new Vector2(GetComponent<RectTransform>().localScale.x, height);

    }


}


