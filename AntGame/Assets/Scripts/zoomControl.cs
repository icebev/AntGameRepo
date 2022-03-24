using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomControl : MonoBehaviour
{
    void Start()
    {
       
    }


    void Update()
    {

        switch (GlobalVars.b_gamePaused)
        {
            case false:
                if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
                {
                }
                else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                {
                }
                break;
        }





    }
}
