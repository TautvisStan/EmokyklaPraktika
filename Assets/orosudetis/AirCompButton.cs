using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCompButton : MonoBehaviour
{
    public GameObject Animation;
    public GameObject Column;
    public Sprite Hover;
    public Sprite Default;
    public AirCompAnimationController MainController;
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
        MainController.StartAnimation(Animation, Column);
    }
}
