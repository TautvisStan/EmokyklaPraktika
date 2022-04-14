using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCompCheckButton : MonoBehaviour
{
    public Sprite Default;
    public Sprite Hover;
    public Sprite Pressed;
    public AirCompMainController main;
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = Hover;
    }
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = Default;
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = Pressed;
        main.CheckInput();
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = Hover;
    }
}
