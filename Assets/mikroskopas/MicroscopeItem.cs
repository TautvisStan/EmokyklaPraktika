using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeItem : MonoBehaviour
{
    public Sprite Image4x;
    public Sprite Image10x;
    public Sprite Image40x;
    public string Name;
    public SpriteRenderer NameText;
    private Camera cam;
    Vector3 ClickOffset;
    public MicroscopeMain Microscope;
    public GameObject PlacementPlace;
    Vector3 mainPos;
    void Awake()
    {
        cam = Camera.main;
        mainPos = transform.position;
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = GetMousePos() - ClickOffset;
        transform.position = mousePos;
    }
    private void OnMouseDown()
    {
        ClickOffset = GetMousePos() - transform.position;
        NameText.color = new Color(1, 1, 1, 0.5f);
    }
    private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, PlacementPlace.transform.position) < 1f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            GetComponent<BoxCollider2D>().enabled = false;
            Microscope.SetItem(this);
        }
        else
        {
            ResetItem();
        }
    }
    public void ResetItem()
    {
        NameText.color = new Color(1, 1, 1, 1);
        transform.position = mainPos;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
