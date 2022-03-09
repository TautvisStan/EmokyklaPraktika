using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ezeroekosistema
{

    public class LakeController : MonoBehaviour
    {
        public LakeItem[] items;
        public void WindowOpened()
        {
            foreach (LakeItem item in items)
            {
                item.ready = false;
            }
        }
        public void WindowClosed()
        {
            foreach (LakeItem item in items)
            {
                item.ready = true;
            }
        }
    }
}