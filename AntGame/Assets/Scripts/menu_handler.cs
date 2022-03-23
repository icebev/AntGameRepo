using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_handler : MonoBehaviour
{
    public Animator MenuScroll;

    private bool animationPlayed;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScrollUp()
    {
        MenuScroll.Play("ScrollUp");
    }

    void ScrollDown()
    {
        MenuScroll.Play("ScrollDown");
    }

    void ScrollLeft()
    {
        MenuScroll.Play("ScrollLeft");
    }

    void ScrollRight()
    {
        MenuScroll.Play("ScrollRight");
    }

    void ScrollLeftToRight()
    {
        MenuScroll.Play("ScrollLeftToRight");
    }

    void ScrollRightToLeft()
    {
        MenuScroll.Play("ScrollRightToLeft");
    }



    

    

}
