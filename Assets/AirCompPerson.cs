using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCompPerson : MonoBehaviour
{
    private Camera cam;
    public AirCompMainController mainController;
    public Sprite BackLooking;
    public Sprite BackClimbing;
    public Sprite FrontWaving;
    public Sprite FrontMask;
    public Sprite BackClimbingMask;
    public Sprite FrontWavingMask;
    bool Masked = false;
    bool CanBeDragged = true;
    bool TheEnd = false;
    Vector3 ClickOffset;
    public void EnableDragging()
    {
        CanBeDragged = true;
    }
    public void DisableDragging()
    {
        CanBeDragged = false;
    }

    void Awake()
    {
        cam = Camera.main;
    }
    public void Set0Sprite()
    {
        Masked = false;
        TheEnd = false;
        GetComponent<SpriteRenderer>().sprite = BackLooking;
    }
    public void Set3000Sprite()
    {
        GetComponent<SpriteRenderer>().sprite = FrontWaving;
    }
    public void Set7000Sprite()
    {
        Masked = true;
        GetComponent<SpriteRenderer>().sprite = FrontMask;
    }
    public void Set8000Sprite()
    {
        TheEnd = true;
        GetComponent<SpriteRenderer>().sprite = FrontWavingMask;
    }
    private void OnMouseDown()
    {
        if (CanBeDragged && !TheEnd)
        {
            ClickOffset = GetMousePos() - transform.position;
            if (!Masked)
            {
                GetComponent<SpriteRenderer>().sprite = BackClimbing;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = BackClimbingMask;
            }
        }
    }
    void OnMouseDrag()
    {
        if (CanBeDragged && !TheEnd)
        {
            Vector3 mousePos = GetMousePos() - ClickOffset;
            mainController.MovingDragged(mousePos);
        }
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
