using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Krivodeling.UI.Effects;
namespace rega
{
    public class SeeingFlowerController : MonoBehaviour
    {
        public GameObject StartPos;
        public GameObject EndPos;
        public GameObject Moving;
        public UIBlur BlurOverlay;
        private float xDist;
        public GameObject FlowerImage;
        public GameObject FlowerImageLeftSide;
        public GameObject FlowerImageRightSide;
        private void Start()
        {
            xDist = EndPos.transform.position.x - StartPos.transform.position.x;
        }
        public void MovingDragged(float xPos)
        {
            if (xPos > EndPos.transform.position.x)
            {
                Moving.transform.position = EndPos.transform.position;
            }
            else
            {
                if (xPos < StartPos.transform.position.x)
                {
                    Moving.transform.position = StartPos.transform.position;
                }
                else
                {
                    if (System.Math.Abs(Moving.transform.position.x - xPos) > 0.001)
                    {
                        Debug.Log(xPos);
                        bool movedRight = false;
                        if (Moving.transform.position.x < xPos)
                        {
                            movedRight = true;
                        }
                        Moving.transform.position = new Vector3(xPos, Moving.transform.position.y);
                        BlurOverlay.Intensity = 1;
                        BlurOverlay.EndBlur(0.5f);
                        float dist = Moving.transform.position.x - StartPos.transform.position.x;
                        float percentage = dist / xDist;
                        if (movedRight)
                        {
                            FlowerImage.transform.position = FlowerImageRightSide.transform.position;
                        }
                        else
                        {
                            FlowerImage.transform.position = FlowerImageLeftSide.transform.position;
                        }
                    }
                }
            }

            
            
        }
    }
}