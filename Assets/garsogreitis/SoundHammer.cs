using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHammer : MonoBehaviour
{
    public SoundWavesCont2 main;
    private void OnMouseDown()
    {
        GetComponent<Animator>().enabled = true;
        main.HammerClicked();
    }
}
