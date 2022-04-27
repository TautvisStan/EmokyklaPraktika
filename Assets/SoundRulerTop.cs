using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRulerTop : MonoBehaviour
{
    private Camera cam;
    Vector3 ClickOffset;
    public SoundRuler Ruler;
    void Awake()
    {
        cam = Camera.main;
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = GetMousePos() - ClickOffset;
        transform.position = mousePos;
        Ruler.GetAngle();
    }
    private void OnMouseDown()
    {
        ClickOffset = GetMousePos() - transform.position;
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
