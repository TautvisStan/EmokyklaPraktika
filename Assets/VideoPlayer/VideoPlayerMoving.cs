using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VideoPlayerCustom
{
    public class VideoPlayerMoving : MonoBehaviour
    {

        private Camera cam;
        private Vector3 position;
        public VideoPlayerMain mainController;


        void Awake()
        {
            cam = Camera.main;
        }

        void OnMouseDown()
        {
            mainController.MovingPressed();
        }
        private void OnMouseUp()
        {
            mainController.MovingReleased();

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