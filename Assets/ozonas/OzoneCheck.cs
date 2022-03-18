using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzoneCheck : MonoBehaviour
{
    public DropdownCustom OxyNum, OxyText, OzoneNum, OzoneText;
    public GameObject Window;
    public GameObject SuccessText;
    public GameObject FailText;
    void OnMouseDown()
    {
        Check();
    }
    public void Check()
    {
        OxyNum.Select(OxyNum.selected);
        OxyText.Select(OxyText.selected);
        OzoneNum.Select(OzoneNum.selected);
        OzoneText.Select(OzoneText.selected);
        if (OxyNum.selected == 1 && OxyText.selected == 1 && OzoneNum.selected == 0 && OzoneText.selected == 0)
        {
            Window.SetActive(true);
            SuccessText.SetActive(true);
            FailText.SetActive(false);
        }
        else
        {
            Window.SetActive(true);
            FailText.SetActive(true);
            SuccessText.SetActive(false);
            if (OxyNum.selected != 1)
                OxyNum.Select(-1);
            if (OxyText.selected != 1)
                OxyText.Select(-1);
            if (OzoneNum.selected != 0)
                OzoneNum.Select(-1);
            if (OzoneText.selected != 0)
                OzoneText.Select(-1);
        }

    }
}
