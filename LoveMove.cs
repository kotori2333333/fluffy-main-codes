using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveMove : MonoBehaviour
{
    public float min = -900;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Febucci.UI.Examples.InitTutorialManager.TTindex >= 27)
        {
            if(GetComponent<RectTransform>().localPosition.x < min)
            {
                GetComponent<RectTransform>().localPosition += new Vector3(1.8f, 0, 0);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
