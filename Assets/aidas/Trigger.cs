using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Aidas
{
    public class Trigger : MonoBehaviour
    {
        public MainScript script;
        void OnMouseDown()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            script.Play();
            Destroy(gameObject);
        }
    }
}
