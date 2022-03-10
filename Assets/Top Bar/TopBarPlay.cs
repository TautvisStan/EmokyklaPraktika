using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopBar
{

    public class TopBarPlay : MonoBehaviour
    {
        public TopBarMain main;
        public GameObject LightButton;
        public GameObject DarkButton;
        void OnMouseDown()
        {
            main.PlayAudio();
            LightButton.SetActive(false);
            DarkButton.SetActive(true);
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
