using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace greicioapskaiciavimas
{
    public class SpeedWindowClose : MonoBehaviour
    {
        public GameObject Window;
        void OnMouseDown()
        {
            Window.SetActive(false);
        }
    }
}