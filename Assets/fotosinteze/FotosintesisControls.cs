using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace fotosinteze
{
    public class FotosintesisControls : MonoBehaviour
    {
        public FotosintesisMain main;
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