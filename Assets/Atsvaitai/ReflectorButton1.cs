using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorButton1 : MonoBehaviour
    {
        public ReflectorController2 main;
        private void OnMouseDown()
        {
            main.ToSecond();
        }
    }
}