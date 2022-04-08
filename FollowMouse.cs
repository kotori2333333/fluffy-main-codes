using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float offset = 2.5f;
    public float sensitivity = 0.07f;
    public Camera current;

    public static bool lookAt = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        if(Febucci.UI.Examples.InitTutorialManager.TTindex == 20)
        {
            GetComponent<LookAtObject>().enabled = true;
        }

        pos = Input.mousePosition;
        pos.z = offset;
        transform.position = current.ScreenToWorldPoint(pos);
        //if (Input.GetKey(KeyCode.R))
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            offset += sensitivity;
        }
        //if (Input.GetKey(KeyCode.F))
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            offset -= sensitivity;
        }
    }
}
