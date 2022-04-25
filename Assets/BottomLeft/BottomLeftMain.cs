using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BottomLeft
{
    public class BottomLeftMain : MonoBehaviour
    {
        private int part = 0;
        public GameObject[] Parts;
        public BottomLeftButton Left;
        public BottomLeftButton Reset;
        public BottomLeftButton Right;
        public void Start()
        {
            Left.DisableButton();
            if (Parts.Length == 1)
            {
                Right.DisableButton();
            }
        }
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
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
            }
            Parts[part].SetActive(true);
            if(part == 0)
            {
                Left.DisableButton();
            }
            else
            {
                Left.EnableButton();
            }
            if (part == Parts.Length - 1)
            {
                Right.DisableButton();
            }
            else
            {
                Right.EnableButton();
            }
        }
    }
}