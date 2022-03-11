using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace maistopiramide
{
    public class PyramidMain : MonoBehaviour
    {
        public PyramidButton[] Buttons;
        public void WindowOpened()
        {
            foreach (PyramidButton button in Buttons)
            {
                button.ready = false;
            }
        }
        public void WindowClosed()
        {
            foreach (PyramidButton button in Buttons)
            {
                button.ready = true;
            }
        }
    }
}
