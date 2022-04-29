using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRuler : MonoBehaviour
{
    private Camera cam;
    Vector3 ClickOffset;
    public SoundWavesCont2 mainController;
    public GameObject LineStart;
    public GameObject LineEnd;
    public SoundRulerLine Line;
    public SoundRulerTop RulerTop;
    public GameObject testObj;
    void Awake()
    {
        cam = Camera.main;
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = GetMousePos() - ClickOffset;
        testObj.transform.position = mousePos;
        Line.UpdateLine();
    }
    private void OnMouseDown()
    {
        ClickOffset = GetMousePos() - testObj.transform.position;
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
    public void GetAngle()
    {        
        float angle = Mathf.Atan2(LineEnd.transform.position.y - LineStart.transform.position.y, LineEnd.transform.position.x - LineStart.transform.position.x);
        testObj.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, testObj.transform.forward);
        Line.UpdateLine();
    }
}
