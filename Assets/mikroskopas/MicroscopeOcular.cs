using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeOcular : MonoBehaviour
{
    public MicroscopeMain main;
    public Sprite DefaultSprite;
    int NextState = 1;
    private void OnMouseDown()
    {
        if(main.Item != null)
        {
            main.ChangeMode();
            StartCoroutine(Switch());
        }
    }
    public void ResetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = DefaultSprite;
        NextState = 1;
    }
    IEnumerator Switch()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().enabled = true;
        Animator anim = GetComponent<Animator>();
        string next = "New Animation" + NextState;
        anim.Play(next, -1, 0f);
        NextState++;
        if(NextState == 4)
        {
            NextState = 1;
        }
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Animator>().enabled = false;
    }
}
