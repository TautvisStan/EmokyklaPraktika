using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownCustom : MonoBehaviour
{
    public string[] values;
    public int selected = 0;
    public TextMeshPro text;
    private bool opened = false;
    public GameObject[] Options;
    public GameObject OpenButton;
    public GameObject CloseButton;
    public void Select(int num)
    {
        opened = false;
        if (num == -1)
            text.text = "";
        else
            text.text = values[num];
        selected = num;
        OpenButton.SetActive(true);
        CloseButton.SetActive(false);
        foreach (GameObject obj in Options)
        {
            obj.SetActive(false);
        }
    }
    void OnMouseDown()
    {
        if (!opened)
        {
            opened = true;
            OpenButton.SetActive(false);
            CloseButton.SetActive(true);
            foreach (GameObject obj in Options)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            Select(selected);
        }
    }
}
