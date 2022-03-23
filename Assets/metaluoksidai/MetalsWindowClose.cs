using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace metaluoksidai
{
    public class MetalsWindowClose : MonoBehaviour
    {
        public GameObject Window;
        void OnMouseDown()
        {
            Window.SetActive(false);
        }
    }
}