using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BottomLeft
{
    public class BottomLeftButton : MonoBehaviour
    {
        public BottomLeftMain main;
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

    }
}