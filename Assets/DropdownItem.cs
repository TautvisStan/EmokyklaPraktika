using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownItem : MonoBehaviour
{
    public int num;
    public DropdownCustom main;

    void OnMouseDown()
    {
        main.Select(num);
    }
}
