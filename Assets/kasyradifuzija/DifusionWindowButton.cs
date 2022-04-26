using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionWindowButton : MonoBehaviour
{
    public Sprite Start;
    public Sprite Pause;
    public Sprite Continue;
    public Sprite Restart;
    public DifusionParticlesCont1 controller;
    string mode = "Start";
    public void SetRestart()
    {
        mode = "Restart";
        GetComponent<SpriteRenderer>().sprite = Restart;
    }
    private void OnMouseDown()
    {
        switch(mode)
        {
            case "Start":
                controller.StartAnimation();
                mode = "Pause";
                GetComponent<SpriteRenderer>().sprite = Pause;
                break;
            case "Pause":
                controller.PauseWindow();
                mode = "Continue";
                GetComponent<SpriteRenderer>().sprite = Continue;
                break;
            case "Continue":
                controller.ResumeWindow();
                mode = "Pause";
                GetComponent<SpriteRenderer>().sprite = Pause;
                break;
            case "Restart":
                controller.RestartWindow();
                mode = "Start";
                GetComponent<SpriteRenderer>().sprite = Start;
                break;
        }
    }
}
