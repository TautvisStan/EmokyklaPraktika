using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace maistopiramide
{
    public class PyramidWindowClose : MonoBehaviour
    {
        public GameObject Window;
        public PyramidMain main;
        void OnMouseDown()
        {
            main.WindowClosed();
            Window.SetActive(false);
        }
    }
}