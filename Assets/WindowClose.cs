using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowClose : MonoBehaviour
{
    public GameObject Window;
    private void OnMouseDown()
    {
        Window.SetActive(false);
    }
}
