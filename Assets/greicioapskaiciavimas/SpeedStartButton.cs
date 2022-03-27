using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace greicioapskaiciavimas
{
    public class SpeedStartButton : MonoBehaviour
    {
        public SpeedMainController main;
        public DropdownCustom dropdown;
        void OnMouseDown()
        {
            main.StartRace();
            dropdown.CloseDropdown();
        }
    }
}