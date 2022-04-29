using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaterial : MonoBehaviour
{
    public string Mode;
    public SoundWavesCont2 main;
    public GameObject Highlight;
    private void OnMouseEnter()
    {
        Highlight.SetActive(true);
    }
    private void OnMouseDown()
    {
        main.MaterialClicked(Mode);
    }
    private void OnMouseExit()
    {
        Highlight.SetActive(false);
    }
}
