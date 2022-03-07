using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Button1 : MonoBehaviour
    {
        // Start is called before the first frame update
        public MenuScript MainMenu;
        public GameObject background1;
        public GameObject background2;
        public Texture2D cursor;


        void OnMouseEnter()
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
            background1.SetActive(false);
            background2.SetActive(true);
        }

        void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            background1.SetActive(true);
            background2.SetActive(false);
        }
        void OnMouseDown()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            MainMenu.OpenMenu1();
            background1.SetActive(true);
            background2.SetActive(false);
        }
    }
}
