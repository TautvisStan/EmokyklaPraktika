using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BottomLeft
{
    public class BottomLeftMain : MonoBehaviour
    {
        private int part = 0;
        public GameObject[] Parts;
        public void ButtonClicked(string command)
        {
            Parts[part].SetActive(false);
            switch (command)
            {
                case "Next":
                    if(part != Parts.Length - 1)
                    {
                        part++;
                    }
                    break;
                case "Back":
                    if (part != 0)
                    {
                        part--;
                    }
                    break;
                case "Reset":
                    part = 0;
                    break;
            }
            Parts[part].SetActive(true);
        }
    }
}