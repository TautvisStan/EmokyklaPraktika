using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowOpen : MonoBehaviour
{

    public GameObject Window;
    private void OnMouseDown()
    {
        Window.SetActive(true);
    }
}
