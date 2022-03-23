using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace metaluoksidai
{
    public class MetalsButton : MonoBehaviour
    {
        public MetalsMain main;
        public GameObject LightButton;
        public GameObject DarkButton;
        void OnMouseDown()
        {
            main.CheckEquation();
        }

        private void OnMouseEnter()
        {
            DarkButton.SetActive(false);
            LightButton.SetActive(true);
        }
        private void OnMouseExit()
        {
            LightButton.SetActive(false);
            DarkButton.SetActive(true);
        }
    }
}