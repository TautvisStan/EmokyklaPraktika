using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeTable : MonoBehaviour
{
    public GameObject BotPos;
    public GameObject DefaultPos;
    public GameObject TopPos;
    public UIBlur FrameBlur;
    public MicroscopeMain main;
    public MicroscopeKnob Knob;
    private void FixedUpdate()
    {
        float intensity = Mathf.Abs(((TopPos.transform.position.y - BotPos.transform.position.y) / 2) - (transform.position.y - BotPos.transform.position.y));
        intensity = intensity / (TopPos.transform.position.y - BotPos.transform.position.y) *2;
        FrameBlur.Intensity = intensity;
    }
    public void UpdatePosition(Vector3 pos)
    {
        if(transform.position.y + pos.y > TopPos.transform.position.y)
        {
            main.TooHigh();
            ResetPosition();
            Knob.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (transform.position.y + pos.y < BotPos.transform.position.y)
        {
            main.TooLow();
            ResetPosition();
            Knob.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            transform.position += pos;
        }
    }
    public void ResetPosition()
    {
        transform.position = DefaultPos.transform.position;
    }

}
