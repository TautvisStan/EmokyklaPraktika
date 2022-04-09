using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rega
{
    public class SeeingFlowerMoving : MonoBehaviour
    {
        private Camera cam;
        public SeeingFlowerController mainController;
        void Awake()
        {
            cam = Camera.main;
        }
        void OnMouseDrag()
        {
            float mousePosX = GetMousePosX();
            mainController.MovingDragged(mousePosX);
        }

        private float GetMousePosX()
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            return mousePos.x;
        }
    }
}