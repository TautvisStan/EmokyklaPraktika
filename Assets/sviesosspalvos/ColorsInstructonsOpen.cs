using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sviesosspalvos
{ 
    public class ColorsInstructonsOpen : MonoBehaviour
    {
        public GameObject Panel;
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
            Panel.SetActive(true);
            background1.SetActive(true);
            background2.SetActive(false);
        }
    }
}
