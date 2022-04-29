using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeKnob : MonoBehaviour
{
    Vector3 ClickOffset;
    float CurrentRotation;
    float CurrentRotation2;
    private Camera cam;
    Vector3 Previous;
    Vector3 Current;
    public MicroscopeTable Table;
    private void Awake()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        CurrentRotation = transform.rotation.eulerAngles.z;
        CurrentRotation2 = Mathf.Atan2(GetMousePos().y - transform.position.y, GetMousePos().x - transform.position.x) * Mathf.Rad2Deg;
        Previous = transform.up;
    }

    void OnMouseDrag()
    {

        Vector3 mousePos = GetMousePos();// - ClickOffset;
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        angle = angle - CurrentRotation2;
        transform.rotation = Quaternion.AngleAxis(CurrentRotation + angle, transform.forward);
        Current = transform.up;
        Vector3 cross = Vector3.Cross(Previous, Current);

        Table.UpdatePosition(new Vector3(0, cross.z * 0.025f, 0));
        Previous = Current;
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
