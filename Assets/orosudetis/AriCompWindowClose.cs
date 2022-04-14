using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriCompWindowClose : MonoBehaviour
{
    public GameObject Window;
    public AirCompMainController mainController;
    private void OnMouseDown()
    {
        mainController.WindowClosed();
        Window.SetActive(false);
    }
}
