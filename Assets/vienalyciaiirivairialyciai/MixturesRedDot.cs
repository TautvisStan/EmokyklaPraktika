using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesRedDot : MonoBehaviour
{
    public GameObject Text;
    private void OnMouseEnter()
    {
        Text.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnMouseExit()
    {
        Text.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
