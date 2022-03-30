using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace klausa
{
    public class HearingImage : MonoBehaviour
    {
        public Sprite[] sprites;
        private SpriteRenderer Image;
        public HearingButton[] buttons;
        private void Start()
        {
            Image = GetComponent<SpriteRenderer>();
        }
        public void SetImage(int num)
        {
            Image.sprite = sprites[num];
            foreach (HearingButton button in buttons)
            {
                button.Unselect();
            }
        }
    }
}