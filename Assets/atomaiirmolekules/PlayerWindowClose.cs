using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{

    public class PlayerWindowClose : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject ExitObj;
        public Material MaterialDef;
        public Material MaterialHover;
        public GlassVideo VideoWindow;
        void OnMouseEnter()
        {
            ExitObj.GetComponent<SpriteRenderer>().material = MaterialHover;

        }

        void OnMouseExit()
        {
            ExitObj.GetComponent<SpriteRenderer>().material = MaterialDef;
        }
        void OnMouseDown()
        {
            ExitObj.GetComponent<SpriteRenderer>().material = MaterialDef;

            VideoWindow.disableDisplay();
        }
    }
}
