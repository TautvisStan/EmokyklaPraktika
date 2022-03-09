using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
namespace VideoPlayerCustom
{
    public class VideoPlayerStop : MonoBehaviour
    {
        public VideoPlayerMain main;
        void OnMouseDown()
        {
            main.Stop();
        }
    }
}