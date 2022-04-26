using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionController1 : MonoBehaviour
{
    public GameObject Smokes1;
    public GameObject Smokes2;
    public GameObject Smokes3;
    public GameObject Smokes4;
    public GameObject Smokes5;
    public GameObject Smokes6;
    public GameObject Smokes7;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Laptop;
    public GameObject Circle;
    public GameObject Window;
    public void Start()
    {
        StartCoroutine(StartingAnimation());
    }
    public void LaptopCicked()
    {
        StartCoroutine(LaptopAnim());
    }
    IEnumerator LaptopAnim()
    {
        Laptop.GetComponent<PolygonCollider2D>().enabled = false;
        Smokes4.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Smokes5.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Smokes6.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Smokes7.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Text1.SetActive(false);
        Text2.SetActive(false);
        Circle.SetActive(true);
        yield return new WaitForSeconds(2);
        Window.SetActive(true);

    }
    IEnumerator StartingAnimation()
    {
        SetFadeIn(Smokes1);
        SetFadeIn(Smokes2);
        SetFadeIn(Smokes3);
        yield return new WaitForSeconds(3);
        SetFadeIn(Smokes4);
        SetFadeIn(Smokes5);
        yield return new WaitForSeconds(3);
        SetFadeIn(Smokes6);
        SetFadeIn(Smokes7);
        yield return new WaitForSeconds(3);
        Text1.SetActive(true);
        yield return new WaitForSeconds(3);
        Text2.SetActive(true);
        yield return new WaitForSeconds(1);
        Laptop.GetComponent<PolygonCollider2D>().enabled = true;
    }
    void SetFadeIn(GameObject obj)
    {
        Keyframe[] alpha = new Keyframe[2];
        alpha[0] = new Keyframe(0, 0);
        alpha[1] = new Keyframe(2f, 0.5f);
        AnimationCurve alphac = new AnimationCurve(alpha);
        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(SpriteRenderer), "m_Color.a", alphac);
        clip.legacy = true;
        Animation anim = obj.GetComponent<Animation>();
        anim.AddClip(clip, "animation");
        anim.Play("animation");
    }
}
