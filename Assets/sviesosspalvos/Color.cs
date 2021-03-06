using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace sviesosspalvos
{
    public class Color : MonoBehaviour
    {

        private Camera cam;
        private Vector3 position;
        public GameObject circle;
        public GameObject target;
        public Animation anim;
        public GameObject label;
        public ColorsController mainController;


        void Awake()
        {
            cam = Camera.main;
        }

        void OnMouseDown()
        {
            position = transform.position;
            mainController.SetColorMode("Circle");
        }
        private void OnMouseUp()
        {
            if (Vector3.Distance(transform.position, target.transform.position) < 1f)
            {
                Keyframe[] ksx = new Keyframe[2];
                ksx[0] = new Keyframe(0, transform.localPosition.x);
                ksx[1] = new Keyframe(1, target.transform.localPosition.x);
                Keyframe[] ksy = new Keyframe[2];
                ksy[0] = new Keyframe(0, transform.localPosition.y);
                ksy[1] = new Keyframe(1, target.transform.localPosition.y);
                AnimationCurve animx = new AnimationCurve(ksx);
                AnimationCurve animy = new AnimationCurve(ksy);
                AnimationClip clip = new AnimationClip();
                clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
                clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
                clip.legacy = true;

                anim.AddClip(clip, "testClip");

                anim.Play("testClip");



                label.SetActive(false);
                mainController.ColorSet(this.gameObject.name);
                mainController.SetColorMode();
                Destroy(this);

            }
            else
            {
                mainController.SetColorMode(this.gameObject.name);
                transform.position = position;
            }

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

        void OnMouseEnter()
        {
            label.SetActive(true);
        }

        void OnMouseExit()
        {
            label.SetActive(false);
        }
    }

}