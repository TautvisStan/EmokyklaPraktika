using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace fotosinteze
{
    public class FotosintesisControls : MonoBehaviour
    {
        public FotosintesisMain main;
        public Sprite Default;
        public Sprite Hover;
        public Sprite Disabled;
        bool isEnabled = true;
        public enum myEnum // your custom enumeration
        {
            Next,
            Back,
            Reset
        };
        public myEnum dropDown = new myEnum();
        void OnMouseDown()
        {
            main.ButtonClicked(dropDown.ToString());
        }
        private void OnMouseEnter()
        {
            if (isEnabled)
            {
                GetComponent<SpriteRenderer>().sprite = Hover;
            }
        }
        private void OnMouseExit()
        {
            if (isEnabled)
            {
                GetComponent<SpriteRenderer>().sprite = Default;
            }
        }
        public void EnableButton()
        {
            isEnabled = true;
            GetComponent<SpriteRenderer>().sprite = Default;
        }
        public void DisableButton()
        {
            isEnabled = false;
            GetComponent<SpriteRenderer>().sprite = Disabled;
        }

    }
}