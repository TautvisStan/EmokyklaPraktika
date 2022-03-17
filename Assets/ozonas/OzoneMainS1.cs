using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ozonas
{


    public class OzoneMainS1 : MonoBehaviour
    {
        public Sprite[] ImageSprites;
        public SpriteRenderer Image;
        public GameObject start;
        public GameObject end;
        public GameObject moving;
        private float yDist;
        public void Start()
        {
            moving.transform.position = start.transform.position;
            yDist = System.Math.Abs( end.transform.position.y - start.transform.position.y);

        }
        public void setImage(int num)
        {
            if (num == 100)
                num = 99;
            Image.sprite = ImageSprites[num];
        }
        public void MovingDragged(float yPos)
        {
            if (yPos < end.transform.position.y)
                moving.transform.position = end.transform.position;
            else
            {
                if (yPos > start.transform.position.y)
                    moving.transform.position = start.transform.position;
                else
                {
                    moving.transform.position = new Vector3(moving.transform.position.x, yPos);
                }
            }
            float dist = System.Math.Abs(moving.transform.position.y - start.transform.position.y);
            float percentage = dist / yDist;
            setImage((int)(ImageSprites.Length * percentage));
        }
    }
}
