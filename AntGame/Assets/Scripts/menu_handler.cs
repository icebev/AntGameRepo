using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_handler : MonoBehaviour
{
    public Animator MenuScroll;

    



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScrollUp()
    {
        MenuScroll.Play("ScrollUp");
    }

    public void ScrollDown()
    {
        MenuScroll.Play("ScrollDown");
    }

    public void ScrollLeft()
    {
        MenuScroll.Play("ScrollLeft");
    }

    public void ScrollRight()
    {
        MenuScroll.Play("ScrollRight");
    }

    public void ScrollLeftToRight()
    {
        MenuScroll.Play("ScrollLeftToRight");
    }

    public void ScrollRightToLeft()
    {
        MenuScroll.Play("ScrollRightToLeft");
    }



    

    

}
