using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VideoPlayerCustom
{
    public class VideoPlayerPause : MonoBehaviour
    {
        public VideoPlayerMain main;
        void OnMouseDown()
        {
            main.Pause();
        }
    }
}