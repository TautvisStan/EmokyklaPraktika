using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopBar
{
    public class TopBarGreen : MonoBehaviour
    {
        public TopBarMain main;
        public GameObject LightButton;
        public GameObject DarkButton;
        private bool Opened = false;
        void OnMouseDown()
        {
            if (Opened)
            {
                Opened = false;
                main.Close();
            }
            else
            {
                Opened = true;
                main.Open();
            }
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