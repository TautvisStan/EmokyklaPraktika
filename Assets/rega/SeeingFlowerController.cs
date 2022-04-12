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
        public SeeingFlowerImage FlowerImage;
        public SeeingLens Lens;
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
                        bool movedRight = false;
                        float percentage = (Moving.transform.position.x - StartPos.transform.position.x) / (EndPos.transform.position.x - StartPos.transform.position.x);
                        if (Moving.transform.position.x < xPos)
                        {
                            movedRight = true;
                        }
                        Moving.transform.position = new Vector3(xPos, Moving.transform.position.y);
                        if (movedRight)
                        {
                            FlowerImage.SetRightPos();
                            
                        }
                        else
                        {
                            FlowerImage.SetLeftPos();
                        }
                        Lens.SetScale(percentage, movedRight);
                        float varA = Lens.transform.position.x - EndPos.transform.position.x;
                        float varB = Lens.transform.position.x - Moving.transform.position.x;



                        FlowerImage.SetScale(varA, varB);
                        BlurOverlay.Intensity = 1;
                        BlurOverlay.EndBlur(0.5f);
                        
                    }
                }
            }

            
            
        }
    }
}