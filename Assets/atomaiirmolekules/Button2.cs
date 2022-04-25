using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Button2 : MonoBehaviour
    {
        
        public MenuScript MainMenu;
        public GameObject background1;
        public GameObject background2;
        void OnMouseEnter()
        {
            background1.SetActive(false);
            background2.SetActive(true);
        }

        void OnMouseExit()
        {
            background1.SetActive(true);
            background2.SetActive(false);
        }
        void OnMouseDown()
        {
            MainMenu.OpenMenu2();
            background1.SetActive(true);
            background2.SetActive(false);
        }
    }
}
