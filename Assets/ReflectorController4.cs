using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorController4 : MonoBehaviour
    {
        public GameObject Button;
        public ReflectorTarget[] Slots;
        public ReflectorItem[] Reds;
        public ReflectorItem[] Whites;
        public ReflectorItem[] Oranges;
        public void CheckForButton()
        {
            bool ready = true;
            foreach (ReflectorTarget slot in Slots)
            {
                if (slot.occupied == false)
                {
                    ready = false;
                }
            }
            Button.SetActive(ready);
        }
        public void PerformCheck()
        {
            foreach (ReflectorTarget slot in Slots)
            {
                bool correct = slot.Check();
                if (!correct)
                {
                    slot.item.ResetItem();

                }
            }
            foreach (ReflectorTarget slot in Slots)
            { 
                if (!slot.occupied)
                {
                    ReflectorItem[] array = null;
                    switch (slot.Color)
                    {
                        case "Red":
                            array = Reds;
                            break;
                        case "White":
                            array = Whites;
                            break;
                        case "Orange":
                            array = Oranges;
                            break;
                    }
                    ReflectorItem spare = null;
                    foreach(ReflectorItem item in array)
                    {
                        if (item.placedIn == null)
                        {
                            spare = item;
                            break;
                        }
                    }
                    spare.MoveTo(slot);
                }
            }
        }
    }
}