using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace greicioapskaiciavimas
{
    public class SpeedDropdown : MonoBehaviour
    {
        private DropdownItem item;
        public DropdownCustom mainDropdown;
        public SpeedMainController main;
        private void Start()
        {
            item = this.GetComponent<DropdownItem>();
        }
        void OnMouseDown()
        {
            if (mainDropdown.opened)
            {
                main.SetDistance(item.num);
            }
        }
    }
}