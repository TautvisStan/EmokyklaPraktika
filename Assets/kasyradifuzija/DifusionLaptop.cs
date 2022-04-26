using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionLaptop : MonoBehaviour
{
    public DifusionController1 main;
    private void OnMouseDown()
    {
        main.LaptopCicked();
    }
}
