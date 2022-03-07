using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject thisMenu;
    public GameObject mainMenu;
    public GameObject background1;
    public GameObject background2;
    void OnMouseEnter()
    {
      //  Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        background1.SetActive(false);
        background2.SetActive(true);
    }

    void OnMouseExit()
    {
      //  Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        background1.SetActive(true);
        background2.SetActive(false);
    }
    void OnMouseDown()
    {
       // Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        //MainMenu.MoveTo2()
        background1.SetActive(true);
        background2.SetActive(false);
        mainMenu.SetActive(true);
        thisMenu.SetActive(false);
    }
}
