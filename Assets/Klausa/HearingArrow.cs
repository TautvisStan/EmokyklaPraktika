using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace klausa
{
    public class HearingArrow : MonoBehaviour
    {
        private Camera cam;
        private Vector3 position;
        public SpriteRenderer Image;
        public Sprite[] Images;
        public GameObject Top;
        public GameObject Bot;
        private float yDist;
        void Awake()
        {
            cam = Camera.main;
            yDist = System.Math.Abs(Top.transform.position.y - Bot.transform.position.y);
        }

        void OnMouseDrag()
        {
            float mousePosY = GetMousePosY();
            if (mousePosY < Bot.transform.position.y)
                transform.position = Bot.transform.position;
            else
            {
                if (mousePosY > Top.transform.position.y)
                    transform.position = Top.transform.position;
                else
                {
                    transform.position = new Vector3(transform.position.x, mousePosY);
                }
            }
            float dist = System.Math.Abs(transform.position.y - Bot.transform.position.y);
            float percentage = dist / yDist;
            if (percentage < 0.25)
            {
                Image.sprite = Images[0];
            }
            if (percentage >= 0.25 && percentage < 0.5)
            {
                Image.sprite = Images[1];
            }
            if (percentage >= 0.5 && percentage < 0.75)
            {
                Image.sprite = Images[2];
            }
            if (percentage >= 0.75)
            {
                Image.sprite = Images[3];
            }
        }

        private float GetMousePosY()
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            return mousePos.y;
        }
    }
}