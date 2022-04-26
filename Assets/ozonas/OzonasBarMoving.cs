using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ozonas
{
    public class OzonasBarMoving : MonoBehaviour
    {

        private Camera cam;
        private Vector3 position;
        public OzoneMainS1 mainController;

        void Awake()
        {
            cam = Camera.main;
        }

        void OnMouseDrag()
        {
            float mousePosY = GetMousePosY();
            mainController.MovingDragged(mousePosY);
        }

        private float GetMousePosY()
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            return mousePos.y;
        }
    }
}