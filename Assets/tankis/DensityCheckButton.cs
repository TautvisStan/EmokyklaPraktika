using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace tankis
{
    public class DensityCheckButton : MonoBehaviour
    {
        public Sprite EnabledButton;
        public Sprite DisabledButton;
        public Sprite HoverButton;
        SpriteRenderer Image;
        public DensityController3 Main;
        bool ready = false;
        private void Start()
        {
            Image = GetComponent<SpriteRenderer>();
        }
        private void OnMouseEnter()
        {
            if (ready)
            {
                Image.sprite = HoverButton;
            }
        }
        private void OnMouseDown()
        {
            if (ready)
            {
                Main.CheckAnswer();
            }
        }
        public void EnableButton()
        {
            ready = true;
            Image.sprite = EnabledButton;
        }
        public void DisableButton()
        {
            ready = false;
            Image.sprite = DisabledButton;
        }
        private void OnMouseExit()
        {
            if (ready)
            {
                Image.sprite = EnabledButton;
            }
        }
    }
}