using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Glass : MonoBehaviour
    {
        public int num;
        public GameObject GlassObj;
        public Material MaterialDef;
        public Material MaterialHover;
        public Menu1 Menu;
        void OnMouseEnter()
        {
            GlassObj.GetComponent<SpriteRenderer>().material = MaterialHover;

        }

        void OnMouseExit()
        {
            GlassObj.GetComponent<SpriteRenderer>().material = MaterialDef;
        }
        void OnMouseDown()
        {
            GlassObj.GetComponent<SpriteRenderer>().material = MaterialDef;
            Menu.DisplayGlass(num);
        }
    }
}