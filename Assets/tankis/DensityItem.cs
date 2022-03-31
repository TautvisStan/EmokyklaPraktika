using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace tankis
{
    public class DensityItem : MonoBehaviour
    {
        public string Name;
        private Vector3 defaultPosition;
        private Camera cam;
        private Animation anim;
        public GameObject[] Targets;
        public int SlotNum = -1;
        public DensityController3 main;
        void Awake()
        {
            cam = Camera.main;
            defaultPosition = transform.localPosition;
            anim = GetComponent<Animation>();
        }
        public void DisableItem()
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        public void ResetItem()
        {
            if (SlotNum != -1)
            {
                Targets[SlotNum].GetComponent<DensitySlot>().occupied = false;
                SlotNum = -1;
            }
            Keyframe[] ksx = new Keyframe[2];
            ksx[0] = new Keyframe(0, transform.localPosition.x);
            ksx[1] = new Keyframe(0.5f, defaultPosition.x);
            Keyframe[] ksy = new Keyframe[2];
            ksy[0] = new Keyframe(0, transform.localPosition.y);
            ksy[1] = new Keyframe(0.5f, defaultPosition.y);
            AnimationCurve animx = new AnimationCurve(ksx);
            AnimationCurve animy = new AnimationCurve(ksy);
            AnimationClip clip = new AnimationClip();
            clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
            clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
            clip.legacy = true;
            anim.AddClip(clip, "testClip");
            anim.Play("testClip");
        }
        void OnMouseDown()
        {
            GetComponent<SpriteRenderer>().sortingOrder = 100;
        }
        private void OnMouseUp()
        {
            GetComponent<SpriteRenderer>().sortingOrder = 99;
            bool placed = false;
            if (SlotNum != -1)
            {
                Targets[SlotNum].GetComponent<DensitySlot>().occupied = false;
                SlotNum = -1;
            }
            foreach (GameObject target in Targets)
            {
                DensitySlot slot = target.GetComponent<DensitySlot>();
                if (Vector3.Distance(transform.position, target.transform.position) < 1f && !slot.occupied)
                {
                    placed = true;
                    SlotNum = slot.SlotNum;
                    slot.occupied = true;
                    slot.value = this.gameObject.name;

                    Keyframe[] ksx = new Keyframe[2];
                    ksx[0] = new Keyframe(0, transform.localPosition.x);
                    ksx[1] = new Keyframe(0.5f, target.transform.localPosition.x);
                    Keyframe[] ksy = new Keyframe[2];
                    ksy[0] = new Keyframe(0, transform.localPosition.y);
                    ksy[1] = new Keyframe(0.5f, target.transform.localPosition.y);
                    AnimationCurve animx = new AnimationCurve(ksx);
                    AnimationCurve animy = new AnimationCurve(ksy);
                    AnimationClip clip = new AnimationClip();
                    clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
                    clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
                    clip.legacy = true;

                    anim.AddClip(clip, "testClip");

                    anim.Play("testClip");

                }
                else
                {

                }
            }
            if (!placed)
            {

                Keyframe[] ksx = new Keyframe[2];
                ksx[0] = new Keyframe(0, transform.localPosition.x);
                ksx[1] = new Keyframe(0.5f, defaultPosition.x);
                Keyframe[] ksy = new Keyframe[2];
                ksy[0] = new Keyframe(0, transform.localPosition.y);
                ksy[1] = new Keyframe(0.5f, defaultPosition.y);
                AnimationCurve animx = new AnimationCurve(ksx);
                AnimationCurve animy = new AnimationCurve(ksy);
                AnimationClip clip = new AnimationClip();
                clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
                clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
                clip.legacy = true;
                anim.AddClip(clip, "testClip");
                anim.Play("testClip");
            }

            main.CheckAllSlots();
        }
        void OnMouseDrag()
        {
            transform.position = GetMousePos();
        }

        Vector3 GetMousePos()
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }
    }
}