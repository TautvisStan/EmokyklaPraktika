using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace tankis
{
    public class DensityDropdown : MonoBehaviour
    {
        private DropdownItem item;
        public DropdownCustom mainDropdown;
        public DensityController main;
        private void Start()
        {
            item = this.GetComponent<DropdownItem>();
        }
        void OnMouseDown()
        {
            if (mainDropdown.opened)
            {
                main.SetMaterial(item.num);
            }
        }
    }
}