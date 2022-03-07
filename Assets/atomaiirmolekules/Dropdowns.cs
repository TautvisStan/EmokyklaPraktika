using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Dropdowns : MonoBehaviour
    {
        public GameObject panel;
        public GameObject Name;
        public Sprite[] sprites;
        public string[] strings;
        
        public void UpdatePanel(int num)
        {
            panel.GetComponent<SpriteRenderer>().sprite = sprites[num];
            Name.GetComponent<TextMeshPro>().text = strings[num];
        }
    }
}