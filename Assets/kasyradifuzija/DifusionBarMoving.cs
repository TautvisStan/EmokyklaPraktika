using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionBarMoving : MonoBehaviour
{
    private Camera cam;
    public DifusionBar mainController;

    void Awake()
    {
        cam = Camera.main;
    }
    private void OnMouseDown()
    {
        mainController.Pressed();
    }
    void OnMouseDrag()
    {
        float mousePosY = GetMousePosY();
        mainController.MovingDragged(mousePosY);
    }
    private void OnMouseUp()
    {
        mainController.Released();
    }

    private float GetMousePosY()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos.y;
    }
}
