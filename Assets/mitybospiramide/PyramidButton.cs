using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace maistopiramide
{
    public class PyramidButton : MonoBehaviour
    {
        public bool ready = true;
        public GameObject Window;
        public PyramidMain main;
        void OnMouseDown()
        {
            if (ready)
            {
                main.WindowOpened();
                Window.SetActive(true);
            }
           
        }
    }
}