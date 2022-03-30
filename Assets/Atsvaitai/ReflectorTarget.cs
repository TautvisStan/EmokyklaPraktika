using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorTarget : MonoBehaviour
    {
        public bool occupied = false;
        public ReflectorItem item;
        public string Color;
        public bool Check()
        {
            return item.Color == Color;
        }
    }
}