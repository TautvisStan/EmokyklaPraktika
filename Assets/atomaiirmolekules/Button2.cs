using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Button2 : MonoBehaviour
    {
        
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
            MainMenu.OpenMenu2();
            background1.SetActive(true);
            background2.SetActive(false);
        }
    }
}
