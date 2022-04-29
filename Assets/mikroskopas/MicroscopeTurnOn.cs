using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeTurnOn : MonoBehaviour
{
    public MicroscopeMain main;
    private void OnMouseDown()
    {
        main.TurnOn();
    }
}
