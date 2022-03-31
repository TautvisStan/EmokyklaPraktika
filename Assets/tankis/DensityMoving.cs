using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace tankis
{
    public class DensityMoving : MonoBehaviour
    {
        private Camera cam;
        private Vector3 position;
        public DensityController mainController;


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