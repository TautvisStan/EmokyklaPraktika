using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorButton2 : MonoBehaviour
    {
        public ReflectorController2 main;
        private void OnMouseDown()
        {
            main.ToThird();
        }
    }
}