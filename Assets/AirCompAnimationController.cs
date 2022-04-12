using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCompAnimationController : MonoBehaviour
{
    public GameObject Window;
    public GameObject[] MainAnimations;
    public void StartAnimation(GameObject Animation, GameObject Column)
    {
        StopAllCoroutines();
        foreach (GameObject obj in MainAnimations)
        {
            obj.SetActive(false);
        }
        Window.SetActive(false);
        StartCoroutine(Animations(Animation, Column));
    }
    IEnumerator Animations(GameObject Animation, GameObject Column)
    {
        Column.SetActive(true);
        Animator anim = Column.GetComponent<Animator>();
        anim.Play("New Animation", -1, 0);
        yield return new WaitForSeconds(2f);
        Window.SetActive(true);
        Animation.SetActive(true);
    }
}