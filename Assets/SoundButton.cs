using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundButton : MonoBehaviour
{
    public string Mode;
    public Sprite Enabled;
    public Sprite Disabled;
    public Sprite Hover;
    public TextMeshPro Text;
    bool buttonEnabled = false;
    public SoundWavesCont2 main;
    public void Rename(string name)
    {
        Text.text = name;
    }
    public void EnableButton()
    {
        buttonEnabled = true;
        GetComponent<SpriteRenderer>().sprite = Enabled;
    }
    public void DisableButton()
    {
        buttonEnabled = false;
        GetComponent<SpriteRenderer>().sprite = Disabled;
    }
    private void OnMouseEnter()
    {
        if(buttonEnabled)
        {
            GetComponent<SpriteRenderer>().sprite = Hover;
        }
    }
    private void OnMouseExit()
    {
        if (buttonEnabled)
        {
            GetComponent<SpriteRenderer>().sprite = Enabled;
        }
    }
    private void OnMouseDown()
    {
        if (buttonEnabled)
        {
            main.ButtonClicked(Mode);
        }
    }
}
