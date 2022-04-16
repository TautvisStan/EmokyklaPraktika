using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesCheckButton : MonoBehaviour
{
    bool ready = false;
    public Sprite Enabled;
    public Sprite Disabled;
    public Sprite Hover;
    public MixturesBoxesController main;
    public void EnableButton()
    {
        ready = true;
        GetComponent<SpriteRenderer>().sprite = Enabled;
    }
    private void OnMouseEnter()
    {
        if(ready)
        {
            GetComponent<SpriteRenderer>().sprite = Hover;
        }
    }
    private void OnMouseExit()
    {
        if (ready)
        {
            GetComponent<SpriteRenderer>().sprite = Enabled;
        }
    }
    private void OnMouseDown()
    {
        if (ready)
        {
            main.PerformCheck();
        }
    }
}
