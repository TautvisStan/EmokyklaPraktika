using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sviesosspalvos
{
    public class Color : MonoBehaviour
    {
        public GameObject label;
        void OnMouseEnter()
        {
            label.SetActive(true);
        }

        void OnMouseExit()
        {
            label.SetActive(false);
        }
    }
}
