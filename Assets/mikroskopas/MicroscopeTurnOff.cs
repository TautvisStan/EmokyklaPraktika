using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeTurnOff : MonoBehaviour
{
    public MicroscopeMain main;
    private void OnMouseDown()
    {
        main.TurnOff();
    }
}
