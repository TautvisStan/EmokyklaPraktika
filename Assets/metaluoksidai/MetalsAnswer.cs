using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace metaluoksidai
{

    public class MetalsAnswer : MonoBehaviour
    {
        public int method;

        public bool IsCorrect(DropdownCustom[] Dropdowns, MetalsSlot[] Slots)
        {
            bool leftGood = false;
            bool rightGood = false;
            if (method == 1)
            {
                if ((Dropdowns[0].text.text == "2" && Slots[0].value == "Mg") && (Dropdowns[1].text.text == "1" && Slots[1].value == "O2"))
                {
                    leftGood = true;
                }
                if ((Dropdowns[0].text.text == "1" && Slots[0].value == "O2") && (Dropdowns[1].text.text == "2" && Slots[1].value == "Mg"))
                {
                    leftGood = true;
                }
                if (Dropdowns[2].text.text == "2" && Slots[2].value == "MgO")
                {
                    rightGood = true;
                }

            }
            else
            {
                if ((Dropdowns[0].text.text == "1" && Slots[0].value == "Fe2O3") && (Dropdowns[1].text.text == "2" && Slots[1].value == "Al"))
                {
                    leftGood = true;
                }
                if ((Dropdowns[0].text.text == "2" && Slots[0].value == "Al") && (Dropdowns[1].text.text == "1" && Slots[1].value == "Fe2O3"))
                {
                    leftGood = true;
                }
                if (Dropdowns[2].text.text == "1" && Dropdowns[3].text.text == "2" && Slots[2].value == "Fe")
                {
                    rightGood = true;
                }
            }
            Debug.Log(leftGood);
            Debug.Log(rightGood);
            if (leftGood && rightGood)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    } 
}
