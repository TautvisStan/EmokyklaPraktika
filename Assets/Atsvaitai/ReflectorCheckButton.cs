using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorCheckButton : MonoBehaviour
    {
        public ReflectorController4 mainController;
        private void OnMouseDown()
        {
            mainController.PerformCheck();
        }
    }
}