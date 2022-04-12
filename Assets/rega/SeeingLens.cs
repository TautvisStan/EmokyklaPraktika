using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Krivodeling.UI.Effects;
namespace rega
{
    public class SeeingLens : MonoBehaviour
    {
        bool rightSide;
        float defaultScaleX;
        float updatedScaleX;
        public UIBlur BlurImage;
        float scaleDiff;
        private void Start()
        {
            defaultScaleX = transform.localScale.x;
            updatedScaleX = defaultScaleX;
        }
        private void Update()
        {
            UpdateScale(BlurImage.Intensity);
        }
        public void SetScale(float percentage, bool SideRight)
        {
            updatedScaleX = defaultScaleX + defaultScaleX * percentage;
            rightSide = SideRight;
            if(rightSide)
            {
                transform.localScale = new Vector3(updatedScaleX * 1.23f,transform.localScale.y );
                scaleDiff = transform.localScale.x - updatedScaleX;
            }
            else
            {
                transform.localScale = new Vector3(updatedScaleX * 1/1.13f, transform.localScale.y);
                scaleDiff = updatedScaleX - transform.localScale.x;
            }
        }
        public void UpdateScale(float percentage)
        {
            if (!rightSide)
            {
                transform.localScale = new Vector3(updatedScaleX - scaleDiff * percentage, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector3(updatedScaleX + scaleDiff * percentage, transform.localScale.y);
            }
        }
    }
}