using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VideoPlayerCustom;
namespace metaluoksidai
{

    public class MetalsBucket : MonoBehaviour
    {
        public VideoPlayerMain videoPlayer;
        public SpriteRenderer Bucket;
        void Update()
        {
            float progress = videoPlayer.ReturnProgress();
            if (progress > 0)
            {
                Bucket.color = new Color(1, 1, 1, videoPlayer.ReturnProgress());
            }
        }
    }
}