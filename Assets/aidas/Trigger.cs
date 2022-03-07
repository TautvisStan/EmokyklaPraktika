using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Aidas
{
    public class Trigger : MonoBehaviour
    {
        public MainScript script;
        public Texture2D cursor;


        void OnMouseEnter()
        {
            Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        }

        void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        void OnMouseDown()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            script.Play();
            Destroy(gameObject);
        }
    }
}
