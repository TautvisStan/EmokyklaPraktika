using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeWindowClose : MonoBehaviour
{
    public GameObject Window;
    public MicroscopeKnob Knob;
    private void OnMouseDown()
    {
        Knob.GetComponent<BoxCollider2D>().enabled = true;
        Window.SetActive(false);
    }
}
