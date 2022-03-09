using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
namespace VideoPlayerCustom
{
    public class VideoPlayerPlay : MonoBehaviour
    {
        public VideoPlayerMain main;
        void OnMouseDown()
        {
            main.Play();
        }
    }
}