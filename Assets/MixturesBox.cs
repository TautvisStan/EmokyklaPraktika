using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesBox : MonoBehaviour
{
    public string Side;
    public MixturesBoxElement[] ElementsInside = new MixturesBoxElement[8];
    public int count = 0;
    public MixturesBoxPanel Panel;
    public GameObject Overlay;
    public MixturesBoxesController controller;
    public void InsertElement(MixturesBoxElement element)
    {
        ElementsInside[count] = element;
        count++;
        controller.CheckForButton();
    }
    public void PutInPanel()
    {
        Panel.PutItems(ElementsInside, count, Side);
    }
}
