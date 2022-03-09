using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ezeroekosistema
{

    public class LakeItem : MonoBehaviour
    {
        public GameObject window;
        public bool ready = true;
        public LakeController controller;

        void OnMouseDown()
        {
            if (ready)
            {
                window.SetActive(true);
                controller.WindowOpened();
            }
        }
    }
}
