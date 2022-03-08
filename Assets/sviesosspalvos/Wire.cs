using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sviesosspalvos
{
    public class Wire : MonoBehaviour
    {
        private Camera cam;
        private Vector3 position;
        public GameObject target;
        public Animation anim;
        public ColorsController mainController;
        void Awake()
        {
            cam = Camera.main;
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



                mainController.WireSet(this.gameObject.name);
                mainController.SetWireMode();

                Destroy(this);

            }
            else
                transform.position = position;
            mainController.SetWireMode();
        }
        void OnMouseDown()
        {
            position = transform.position;
            mainController.SetWireMode(this.gameObject.name);
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