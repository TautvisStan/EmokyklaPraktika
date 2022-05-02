using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorItem : MonoBehaviour
    {
        public GameObject[] targets;
        public bool moved = false;
        public Vector3 StartingPosition;
        public Vector3 StartingRotation;
        public Vector3 StartingScale;
        public string Color;
        private Camera cam;
        public ReflectorTarget placedIn;
        public ReflectorController4 mainController;
        void OnMouseDrag()
        {
            transform.localPosition = GetMousePos();
        }
        public void MoveTo(ReflectorTarget target)
        {
            placedIn = target;
            placedIn.occupied = true;
            target.item = this;
            Keyframe[] posx = new Keyframe[2];
            posx[0] = new Keyframe(0, transform.localPosition.x);
            posx[1] = new Keyframe(0.5f, target.gameObject.transform.localPosition.x);
            Keyframe[] posy = new Keyframe[2];
            posy[0] = new Keyframe(0, transform.localPosition.y);
            posy[1] = new Keyframe(0.5f, target.gameObject.transform.localPosition.y);
            AnimationCurve animx = new AnimationCurve(posx);
            AnimationCurve animy = new AnimationCurve(posy);
            Keyframe[] rotx = new Keyframe[2];
            rotx[0] = new Keyframe(0, transform.localEulerAngles.x);
            rotx[1] = new Keyframe(0.5f, target.gameObject.transform.localEulerAngles.x);
            Keyframe[] rotz = new Keyframe[2];
            rotz[0] = new Keyframe(0, transform.localEulerAngles.z);
            rotz[1] = new Keyframe(0.5f, target.gameObject.transform.localEulerAngles.z);
            Keyframe[] roty = new Keyframe[2];
            roty[0] = new Keyframe(0, transform.localEulerAngles.y);
            roty[1] = new Keyframe(0.5f, target.gameObject.transform.localEulerAngles.y);
            AnimationCurve animx2 = new AnimationCurve(rotx);
            AnimationCurve animy2 = new AnimationCurve(roty);
            AnimationCurve animz2 = new AnimationCurve(rotz);
            Keyframe[] scax = new Keyframe[2];
            scax[0] = new Keyframe(0, transform.localScale.x);
            scax[1] = new Keyframe(0.5f, target.gameObject.transform.localScale.x);
            Keyframe[] scay = new Keyframe[2];
            scay[0] = new Keyframe(0, transform.localScale.y);
            scay[1] = new Keyframe(0.5f, target.gameObject.transform.localScale.y);
            AnimationCurve animx3 = new AnimationCurve(scax);
            AnimationCurve animy3 = new AnimationCurve(scay);
            AnimationClip clip = new AnimationClip();
            clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
            clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
            clip.SetCurve("", typeof(Transform), "localEulerAngles.x", animx2);
            clip.SetCurve("", typeof(Transform), "localEulerAngles.y", animy2);
            clip.SetCurve("", typeof(Transform), "localEulerAngles.z", animz2);
            clip.SetCurve("", typeof(Transform), "localScale.x", animx3);
            clip.SetCurve("", typeof(Transform), "localScale.y", animy3);
            clip.legacy = true;
            Animation anim = this.GetComponent<Animation>();
            anim.AddClip(clip, "testClip");
            anim.Play("testClip");
        }
        public void ResetItem()
        {
            if (placedIn != null)
            {
                placedIn.occupied = false;
                placedIn.item = null;
                placedIn = null;
            }
            transform.position = StartingPosition;
            transform.localEulerAngles = StartingRotation;
            transform.localScale = StartingScale;
        }
        private void OnMouseDown()
        {
            if (placedIn != null)
            {
                placedIn.occupied = false;
                placedIn.item = null;
                placedIn = null;
            }
            transform.localEulerAngles = StartingRotation;
            transform.localScale = StartingScale;
            mainController.CheckForButton();
        }
        Vector3 GetMousePos()
        {
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }
        void Awake()
        {
            cam = Camera.main;
            StartingPosition = transform.position;
            StartingRotation = transform.localEulerAngles;
            StartingScale = transform.localScale;
        }
        private void OnMouseUp()
        {
            bool placed = false;
            /*if (SlotNum != -1)
            {
                Targets[SlotNum].GetComponent<MetalsSlot>().occupied = false;
                SlotNum = -1;
            }*/
            foreach (GameObject target in targets)
            {
                ReflectorTarget slot = target.GetComponent<ReflectorTarget>();
                if (Vector3.Distance(transform.position, target.transform.position) < 1f && !slot.occupied)
                {
                    
                    placed = true;
                    slot.occupied = true;
                    placedIn = slot;
                    placedIn.item = this;
                    transform.position = target.transform.position;
                    transform.rotation = target.transform.rotation;
                    transform.localScale = target.transform.localScale;

                }
                else
                {

                }
            }
            if (!placed)
            {
                transform.position = StartingPosition;
                transform.localEulerAngles = StartingRotation;
                transform.localScale = StartingScale;
            }
            mainController.CheckForButton();
        }
    }
}