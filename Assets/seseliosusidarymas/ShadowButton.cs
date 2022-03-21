using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace seseliosusidarymas
{
    public class ShadowButton : MonoBehaviour
    {
        public GameObject Window;
        public GameObject LightButton;
        public GameObject DarkButton;
        void OnMouseDown()
        {
            Window.SetActive(true);
        }
        void OnMouseEnter()
        {
            LightButton.SetActive(false);
            DarkButton.SetActive(true);
        }
        void OnMouseExit()
        {
            LightButton.SetActive(true);
            DarkButton.SetActive(false);
        }
    }
}