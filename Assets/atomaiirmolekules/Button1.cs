using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Button1 : MonoBehaviour
    {
        // Start is called before the first frame update
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
            MainMenu.OpenMenu1();
            background1.SetActive(true);
            background2.SetActive(false);
        }
    }
}
