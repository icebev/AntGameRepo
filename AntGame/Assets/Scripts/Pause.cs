using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obj_Pause;

    void Start()
    {
        GlobalVars.b_gamePaused = false;
        Time.timeScale = 1;
        Obj_Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (GlobalVars.b_gamePaused)
            {
                case false:
                    GlobalVars.b_gamePaused = true;
                    Time.timeScale = 0;
                    Obj_Pause.SetActive(true);
                    break;

                case true:
                    GlobalVars.b_gamePaused = false;
                    Time.timeScale = 1;
                    Obj_Pause.SetActive(false);
                    break;
            }


        }
    }
}
