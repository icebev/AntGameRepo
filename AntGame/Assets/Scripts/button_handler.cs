using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class button_handler : MonoBehaviour
{
    private int previousMenuState;
    private int currentMenuState;


    public menu_handler Title;
    public menu_handler Saves;
    public menu_handler Options;
    public menu_handler Credits;

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

        currentMenuState = (int)MenuStates.Title;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoBack()
    {
        switch (currentMenuState)
        {


            case (int)MenuStates.Saves:
                Title.ScrollRightToLeft();
                Saves.ScrollLeft();
                currentMenuState = (int)MenuStates.Title;
                break;
            case (int)MenuStates.Options:
                Title.ScrollUp();
                Options.ScrollUp();
                currentMenuState = (int)MenuStates.Title;
                break;
            case (int)MenuStates.Credits:
                
                Title.ScrollLeftToRight();
                Credits.ScrollRight();
                currentMenuState = (int)MenuStates.Title;
                break;

        }


    }

    public void StartGame()
    {
        switch (currentMenuState)
        {
            case (int)MenuStates.Title:

                //Title.ScrollRight();
                //Saves.ScrollRight();
                //currentMenuState = (int)MenuStates.Saves;
                SceneManager.LoadScene(1);
                break;
        }
    }

    public void OptionsMenu()
    {
        switch (currentMenuState)
        {
            case (int)MenuStates.Title:

                Title.ScrollDown();
                Options.ScrollDown();
                currentMenuState = (int)MenuStates.Options;
                break;
        }
    }
    public void CreditsMenu()
    {
        switch (currentMenuState)
        {
            case (int)MenuStates.Title:
                Title.ScrollLeft();
                Credits.ScrollLeft();
                currentMenuState = (int)MenuStates.Credits;
                break;
        }
    }

    public void loadSave1() 
    {
        switch (currentMenuState)
        {
            case (int)MenuStates.Saves:
                SceneManager.LoadScene(1);
                break;
        }
    }
}
