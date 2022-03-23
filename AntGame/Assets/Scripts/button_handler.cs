using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_handler : MonoBehaviour
{
    private int previousMenuState;
    private int currentMenuState;

    public GameObject Title;
    public GameObject Saves;
    public GameObject Options;
    public GameObject Credits;
    

    enum MenuStates
    {
        Title,
        Saves,
        Options,
        Credits,
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoBack()
    {
        switch (currentMenuState)
        {


            case (int)MenuStates.Saves:
                //Title.ScrollLeftToRight();
                //Saves.ScrollLeft();

                break;
            case (int)MenuStates.Options:
                //Title.ScrollUp();
                //Options.ScrollUp();

                break;
            case (int)MenuStates.Credits:
                //Title.ScrollRightToLeft();
                //Credits.ScrollLeft();
                break;

        }


    }

    void StartGame()
    {
        //Title.ScrollRight();
        //Saves.ScrollRight();

    }

    void OptionsMenu()
    {
        //Title.ScrollDown();
        //Options.ScrollDown();

    }

    void CreditsMenu()
    {
        //Title.ScrollLeft();
        //Credits.ScrollLeft();

    }
}
