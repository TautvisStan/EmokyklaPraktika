using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopBar
{
    public class TopBarMain : MonoBehaviour
    {
        public AudioSource audioSource;
        public GameObject PlayButton;
        public GameObject PauseButton;
        public GameObject StopButton;
        public GameObject ClosedPosition;
        public GameObject OpenedPosition;
        public GameObject RealPosition;
        public GameObject GreenButton;
        public Animation anim;

        public void PlayAudio()
        {
            audioSource.Play();
            PlayButton.SetActive(false);
            PauseButton.SetActive(true);
        }
        public void PauseAudio()
        {
            audioSource.Pause();
            PauseButton.SetActive(false);
            PlayButton.SetActive(true);
        }
        public void StopAudio()
        {
            audioSource.Stop();
            PauseButton.SetActive(false);
            PlayButton.SetActive(true);
        }
        public void Open()
        {
            GreenButton.transform.Rotate(0, 0, 180);
            Keyframe[] ksx = new Keyframe[2];
            ksx[0] = new Keyframe(0, RealPosition.transform.localPosition.x);
            ksx[1] = new Keyframe(1, OpenedPosition.transform.localPosition.x);
            Keyframe[] ksy = new Keyframe[2];
            ksy[0] = new Keyframe(0, RealPosition.transform.localPosition.y);
            ksy[1] = new Keyframe(1, OpenedPosition.transform.localPosition.y);
            AnimationCurve animx = new AnimationCurve(ksx);
            AnimationCurve animy = new AnimationCurve(ksy);
            AnimationClip clip = new AnimationClip();
            clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
            clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
            clip.legacy = true;

            anim.AddClip(clip, "Open");

            anim.Play("Open");
        }
        public void Close()
        {
            GreenButton.transform.Rotate(0, 0, 0);
            GreenButton.transform.Rotate(0, 0, 180);
            Keyframe[] ksx = new Keyframe[2];
            ksx[0] = new Keyframe(0, RealPosition.transform.localPosition.x);
            ksx[1] = new Keyframe(1, ClosedPosition.transform.localPosition.x);
            Keyframe[] ksy = new Keyframe[2];
            ksy[0] = new Keyframe(0, RealPosition.transform.localPosition.y);
            ksy[1] = new Keyframe(1, ClosedPosition.transform.localPosition.y);
            AnimationCurve animx = new AnimationCurve(ksx);
            AnimationCurve animy = new AnimationCurve(ksy);
            AnimationClip clip = new AnimationClip();
            clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
            clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
            clip.legacy = true;

            anim.AddClip(clip, "Close");

            anim.Play("Close");
        }

    }
}