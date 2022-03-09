using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ezeroekosistema
{
    public class CloseButton : MonoBehaviour
    {
        public GameObject window;
        public LakeController controller;
        void OnMouseDown()
        {
            controller.WindowClosed();
            window.SetActive(false);
            
        }
    }
}