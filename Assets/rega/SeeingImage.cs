using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rega
{
    public class SeeingImage : MonoBehaviour
    {
        public Sprite[] sprites;
        private SpriteRenderer Image;
        public SeeingButton[] buttons;
        private void Start()
        {
            Image = GetComponent<SpriteRenderer>();
        }
        public void SetImage(int num)
        {
            Image.sprite = sprites[num];
            foreach (SeeingButton button in buttons)
            {
                button.Unselect();
            }
        }
    }
}