using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzoneWindowClose : MonoBehaviour
{
    public GameObject Window;
    void OnMouseDown()
    {
        Window.SetActive(false);
    }
}
