using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace metaluoksidai
{

    public class MetalsMain : MonoBehaviour
    {
        public GameObject EnabledButton;
        public GameObject DisabledButton;
        public MetalsSlot[] Slots;
        public DropdownCustom[] Dropdowns;
        public GameObject Window;
        public GameObject GoodText;
        public GameObject BadText;
        public MetalsTab LeftTab;
        public MetalsTab RightTab;
        public MetalsAnswer Answer;

        public void ChangeTab(MetalsTab tab)
        {
            if (tab == LeftTab)
            {
                LeftTab.GreenButton.GetComponent<SpriteRenderer>().sortingOrder = 8;
                RightTab.GreenButton.GetComponent<SpriteRenderer>().sortingOrder = 2;
                RightTab.GreenButton.SetActive(false);
                RightTab.DarkButton.SetActive(true);
                LeftTab.Video.SetActive(true);
                RightTab.Video.SetActive(false);
                LeftTab.active = true;
                RightTab.active = false;
            }
            else
            {
                LeftTab.GreenButton.GetComponent<SpriteRenderer>().sortingOrder = 2;
                RightTab.GreenButton.GetComponent<SpriteRenderer>().sortingOrder = 8;
                LeftTab.GreenButton.SetActive(false);
                LeftTab.DarkButton.SetActive(true);
                LeftTab.Video.SetActive(false);
                RightTab.Video.SetActive(true);
                LeftTab.active = false;
                RightTab.active = true;
            }
        }
        public void CheckAllSlots()
        {
            bool ready = true;
            foreach (MetalsSlot slot in Slots)
            {
                if (!slot.occupied)
                {
                    ready = false;
                }
            }
            if (ready)
            {
                EnabledButton.SetActive(true);
                DisabledButton.SetActive(false);
            }
            else
            {
                DisabledButton.SetActive(true);
                EnabledButton.SetActive(false);
            }
        }
        public void CheckEquation()
        {
            Window.SetActive(true);
            if (Answer.IsCorrect(Dropdowns, Slots))
            {
                GoodText.SetActive(true);
                BadText.SetActive(false);
            }
            else
            {
                GoodText.SetActive(false);
                BadText.SetActive(true);
            }


            

        }
    }
}