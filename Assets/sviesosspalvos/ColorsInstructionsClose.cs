using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sviesosspalvos
{
    public class ColorsInstructionsClose : MonoBehaviour
    {
        public GameObject Panel;
        void OnMouseDown()
        {
            Panel.SetActive(false);
        }
    }
}