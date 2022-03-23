using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace metaluoksidai
{

    public class MetalsTab : MonoBehaviour
    {
        public GameObject DarkButton;
        public GameObject GreenButton;
        public GameObject Video;
        public MetalsMain main;
        public bool active = false;
        void OnMouseDown()
        {
            DarkButton.SetActive(false);
            GreenButton.SetActive(true);
            main.ChangeTab(this);
        }

        private void OnMouseEnter()
        {
            if (!active)
            {
                DarkButton.SetActive(false);
                GreenButton.SetActive(true);
            }
        }
        private void OnMouseExit()
        {
            if (!active)
            {
                GreenButton.SetActive(false);
                DarkButton.SetActive(true);
            }
        }
    }
}
