using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesBoxElement : MonoBehaviour
{
    public string Name;
    public string Side;
    private Camera cam;
    public MixturesBox[] Boxes;
    Vector3 DefaultPos;
    public GameObject MiddleImage;

    void Awake()
    {
        cam = Camera.main;
        DefaultPos = transform.position;
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 11;
    }
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 10;
        bool placed = false;
        foreach (MixturesBox Box in Boxes)
        {
            
            if (Vector3.Distance(transform.position, Box.transform.position) < 3f)
            {
                Box.Overlay.SetActive(false);
                Box.InsertElement(this);
                placed = true;
                Keyframe[] ksx = new Keyframe[2];
                ksx[0] = new Keyframe(0, transform.localPosition.x);
                ksx[1] = new Keyframe(0.25f, Box.transform.localPosition.x);
                Keyframe[] ksy = new Keyframe[2];
                ksy[0] = new Keyframe(0, transform.localPosition.y);
                ksy[1] = new Keyframe(0.25f, Box.transform.localPosition.y);

                Keyframe[] ksxSc = new Keyframe[2];
                ksxSc[0] = new Keyframe(0, transform.localScale.x);
                ksxSc[1] = new Keyframe(0.25f, 0);
                Keyframe[] ksySc = new Keyframe[2];
                ksySc[0] = new Keyframe(0, transform.localScale.y);
                ksySc[1] = new Keyframe(0.25f, 0);

                AnimationCurve animx = new AnimationCurve(ksx);
                AnimationCurve animy = new AnimationCurve(ksy);
                AnimationCurve animxSc = new AnimationCurve(ksxSc);
                AnimationCurve animySc = new AnimationCurve(ksySc);
                AnimationClip clip = new AnimationClip();
                clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
                clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
                clip.SetCurve("", typeof(Transform), "localScale.x", animxSc);
                clip.SetCurve("", typeof(Transform), "localScale.y", animySc);
                clip.legacy = true;
                Animation anim = GetComponent<Animation>();
                anim.AddClip(clip, "testClip");

                anim.Play("testClip");

            }
        }
        if(!placed)
        {
            transform.position = DefaultPos;
        }
    }
    void OnMouseDrag()
    {
        transform.position = GetMousePos();
        foreach (MixturesBox Box in Boxes)
        {

            if (Vector3.Distance(transform.position, Box.transform.position) < 3f)
            {
                Box.Overlay.SetActive(true);
            }
            else
            {
                Box.Overlay.SetActive(false);
            }
        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
