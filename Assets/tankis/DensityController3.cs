using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace tankis
{
    public class DensityController3 : MonoBehaviour
    {
        public DensityCheckButton Button;
        public DensitySlot[] Slots;
        public DensityItem[] Items;
        public GameObject Window;
        public GameObject GoodText;
        public GameObject BadText;
        public void CheckAllSlots()
        {
            bool ready = true;
            foreach (DensitySlot slot in Slots)
            {
                if (!slot.occupied)
                {
                    ready = false;
                }
            }
            if (ready)
            {
                Button.EnableButton();
            }
            else
            {
                Button.DisableButton();
            }
        }
        public void CheckAnswer()
        {
            Window.SetActive(true);
            if (Slots[0].value == "193" && Slots[1].value == "105")
            {
                GoodText.SetActive(true);
                BadText.SetActive(false);
                Items[0].DisableItem();
                Items[1].DisableItem();
                Button.DisableButton();
            }
            else
            {
                GoodText.SetActive(false);
                BadText.SetActive(true);
                Items[0].ResetItem();
                Items[1].ResetItem();
                Button.DisableButton();
            }
        }
    }
}