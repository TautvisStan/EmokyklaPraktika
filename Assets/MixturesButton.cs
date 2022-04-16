using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesButton : MonoBehaviour
{
    public Sprite Default;
    public Sprite Selected;
    public GameObject Panels;
    bool selected = false;
    public bool timer = true;
    public MixturesThreePanelsController main;
    public MixturesAbstractAnim Animation;
    private void OnMouseDown()
    {
        main.SelectButton(this);
    }
    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().sprite = Selected;
    }
    private void OnMouseExit()
    {
        if(!selected)
        {
            GetComponent<SpriteRenderer>().sprite = Default;
        }
    }
    public void Select()
    {
        selected = true;
        Panels.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = Selected;
    }
    public void Unselect()
    {
        selected = false;
        Panels.SetActive(false);
        GetComponent<SpriteRenderer>().sprite = Default;
    }
}
