using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rega
{
    public class SeeingButton : MonoBehaviour
    {
        private SpriteRenderer Image;
        public int imageID;
        public Sprite SelectedBackground;
        public Sprite HoverBackground;
        public Sprite NotSelectedBackground;
        public bool selected = false;
        public SeeingImage main;
        private void Start()
        {
            Image = GetComponent<SpriteRenderer>();
        }
        public void Unselect()
        {
            selected = false;
            Image.sprite = NotSelectedBackground;
        }
        void OnMouseDown()
        {
            if (!selected)
            {
                main.SetImage(imageID);
                selected = true;
                Image.sprite = SelectedBackground;
            }
        }
        private void OnMouseEnter()
        {
            if (!selected)
            {
                Image.sprite = HoverBackground;
            }
        }
        private void OnMouseExit()
        {
            if (!selected)
            {
                Image.sprite = NotSelectedBackground;
            }
        }
    }
}