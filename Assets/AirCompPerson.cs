using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCompPerson : MonoBehaviour
{
    private Camera cam;
    public AirCompMainController mainController;
    void Awake()
    {
        cam = Camera.main;
    }
    void OnMouseDrag()
    {
        Vector3 mousePosX = GetMousePos();
        mainController.MovingDragged(mousePosX);
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
