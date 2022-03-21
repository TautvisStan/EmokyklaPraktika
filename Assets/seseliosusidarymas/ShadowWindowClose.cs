using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace seseliosusidarymas
{
    public class ShadowWindowClose : MonoBehaviour
    {
        void OnMouseDown()
        {
            this.gameObject.SetActive(false);
        }
    }
}