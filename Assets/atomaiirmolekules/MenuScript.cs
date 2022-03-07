using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class MenuScript : MonoBehaviour
    {
        public GameObject MainMenu;
        public GameObject Menu1;
        public GameObject Menu2;
        
        public void OpenMenu1()
        {
            Menu1.SetActive(true);
            MainMenu.SetActive(false);
        }
        public void OpenMenu2()
        {
            Menu2.SetActive(true);
            MainMenu.SetActive(false);
        }
    }
}
