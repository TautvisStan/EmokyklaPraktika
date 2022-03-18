using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace seseliosusidarymas
{
    public class Pencil : MonoBehaviour
    {

        private Camera cam;
        public GameObject ShelfPosition;
        public GameObject LeftPosition;
        public GameObject MiddlePosition;
        public GameObject RightPosition;
        public string DefaultText;
        public string DraggedText;
        public TextMeshPro TopText;
        public GameObject Shadow;
        public GameObject DefaultArrow;
        public GameObject PlaceArrows;

        void Awake()
        {
            cam = Camera.main;
        }

        void OnMouseDown()
        {
            Shadow.SetActive(false);
            TopText.text = DraggedText;
            DefaultArrow.SetActive(false);
            PlaceArrows.SetActive(true);
        }
        private void OnMouseUp()
        {
            Shadow.SetActive(false);
            PlaceArrows.SetActive(false);
            if (Vector3.Distance(transform.position, LeftPosition.transform.position) < 1f)
            {
                transform.position = LeftPosition.transform.position;
            }
            else
            {
                if (Vector3.Distance(transform.position, MiddlePosition.transform.position) < 1f)
                {
                    Shadow.SetActive(true);
                    transform.position = MiddlePosition.transform.position;
                }
                else
                {
                    if (Vector3.Distance(transform.position, RightPosition.transform.position) < 1f)
                    {
                        transform.position = RightPosition.transform.position;
                    }
                    else
                    {
                        TopText.text = DefaultText;
                        transform.position = ShelfPosition.transform.position;
                        DefaultArrow.SetActive(true);
                    }
                }
            }

        }
        void OnMouseDrag()
        {
            transform.position = GetMousePos();
        }

        Vector3 GetMousePos()
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }
    }
}