using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidas : MonoBehaviour
{
    public GameObject State1;
    public GameObject State2;
    public GameObject State3;
    public GameObject State4;
    public Animator Zmogus;
    public Animator Suo;
    public Animator Balsas1;
    public Animator Balsas2;
    public Animator Aidas1;
    public Animator Aidas2;
    public void Start()
    {
        
        StartCoroutine(movie());
    }

    IEnumerator movie()
    {
     /*   State1.SetActive(false);
        State2.SetActive(true);
        Debug.Log("testas2");
        Zmogus.enabled = true;
        yield return new WaitForSeconds((float)0.7);
        Balsas1.enabled = true;
        yield return new WaitForSeconds(1);
        Aidas1.enabled = true;
        yield return new WaitForSeconds(10);*/
        State2.SetActive(false);
        State3.SetActive(true);
        Suo.enabled = true;
        yield return new WaitForSeconds((float)0.2);
        Balsas2.enabled = true;
        yield return new WaitForSeconds((float)0.5);
        Aidas2.enabled = true;
    }
}
