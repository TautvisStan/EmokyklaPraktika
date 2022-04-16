using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MixturesPanelItem : MonoBehaviour
{
    public TextMeshPro Name;
    public SpriteRenderer Check;
    public Sprite correct;
    public Sprite wrong;
    public bool selected = false;
    public GameObject DefaultBack;
    public GameObject ArrowBack;
    public GameObject MiddleImage;
    public MixturesMiddle controller;
    public void InsertItem(MixturesBoxElement element, string side)
    {
        Name.text = element.Name;
        MiddleImage = element.MiddleImage;
        if (element.Side == side)
        {
            Check.sprite = correct;
        }
        else
        {
            Check.sprite = wrong;
        }

    }
    private void OnMouseDown()
    {
        controller.SelectItem(this);
    }
    private void OnMouseEnter()
    {
        DefaultBack.SetActive(false);
        ArrowBack.SetActive(true);
    }
    private void OnMouseExit()
    {
        if(!selected)
        {
            DefaultBack.SetActive(true);
            ArrowBack.SetActive(false);
        }
    }
    public void Unselect()
    {
        selected = false;
        DefaultBack.SetActive(true);
        ArrowBack.SetActive(false);
        MiddleImage.SetActive(false);
    }
    public void Select()
    {
        selected = true;
        DefaultBack.SetActive(false);
        ArrowBack.SetActive(true);
        MiddleImage.SetActive(true);
    }
}
