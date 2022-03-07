using UnityEngine;

public class Test : MonoBehaviour
{
    
    private Vector3 _dragOffset;
    private Camera _cam;
    private Vector3 position;
    public GameObject circle;
    private bool inPosition = false;


    void Awake()
    {
        _cam = Camera.main;
    }

    void OnMouseDown()
    {
        position = transform.position;
        _dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, circle.transform.position) < 1f)
        {
            Debug.Log("TEST");
        }
        else
            transform.position = position;
    }
    void OnMouseDrag()
    {
        transform.position = GetMousePos();

    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}

/*   Debug.Log("TEST");
   inPosition = true;*/