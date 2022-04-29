using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MicroscopeMain : MonoBehaviour
{
    public SpriteRenderer FrameImage;
    public MicroscopeItem Item;
    public string Mode = "4X";
    public MicroscopeTable Table;
    public GameObject SwitchOn;
    public GameObject SwitchOff;
    public GameObject NoLightImage;
    public GameObject Light;
    public GameObject Window;
    public TextMeshPro WindowText;
    public Sprite BrokenImage;
    public TextMeshPro FrameName;
    public MicroscopeOcular Ocular;
    public GameObject MilkAnim;
    public void TooHigh()
    {
        if(Mode == "40X")
        {
            Window.SetActive(true);
            WindowText.text = "Stalelį pakėlėte per aukštai, todėl sudužo preparato stikliukas.";
        }
        else
        {
            Window.SetActive(true);
            WindowText.text = "Stalelį pakėlėte per aukštai.";
        }
    }
    public void TooLow()
    {
        Window.SetActive(true);
        WindowText.text = "Per žemai nuleidote stalelį.";
    }
    public void TurnOn()
    {
        NoLightImage.SetActive(true);
        Light.SetActive(false);
        SwitchOn.SetActive(false);
        SwitchOff.SetActive(true);
    }
    public void TurnOff()
    {
        NoLightImage.SetActive(false);
        Light.SetActive(true);
        SwitchOn.SetActive(true);
        SwitchOff.SetActive(false);
    }
    public void SetItem(MicroscopeItem item)
    {
        MilkAnim.SetActive(false);
        ResetTablePos();
        Ocular.ResetSprite();
        if (Item != null)
        {
            Item.ResetItem();
        }
        Item = item;
        FrameName.text = item.Name;
        Mode = "4X";
        FrameImage.sprite = Item.Image4x;
    }
    public void ChangeMode()
    {
        MilkAnim.SetActive(false);
        ResetTablePos();
        switch (Mode)
        {
            case "4X":
                Mode = "10X";
                if(Item != null)
                    FrameImage.sprite = Item.Image10x;
                break;
            case "10X":
                Mode = "40X";
                if (Item != null)
                {
                    if (Item.Name != "Pieno lašas")
                        FrameImage.sprite = Item.Image40x;
                    else
                        MilkAnim.SetActive(true);
                }
                break;
            case "40X":
                Mode = "4X";
                if (Item != null)
                    FrameImage.sprite = Item.Image4x;
                break;
        }
    }
    public void ResetTablePos()
    {
        Table.ResetPosition();
    }
}
