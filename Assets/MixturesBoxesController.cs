using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesBoxesController : MonoBehaviour
{
    public MixturesBox[] Boxes;
    public MixturesCheckButton Button;
    public GameObject Middle;
    public void CheckForButton()
    {
        int howMany = 0;
        foreach(MixturesBox Box in Boxes)
        {
            howMany += Box.count;
        }
        if (howMany == 8)
        {
            Button.EnableButton();
        }
    }
    public void PerformCheck()
    {
        Middle.SetActive(true);
        foreach (MixturesBox Box in Boxes)
        {
            Box.PutInPanel();
        }
        Button.gameObject.SetActive(false);
    }
}
