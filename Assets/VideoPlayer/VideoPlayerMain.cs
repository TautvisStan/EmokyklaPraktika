using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
namespace VideoPlayerCustom
{

    public class VideoPlayerMain : MonoBehaviour
    {
        public VideoPlayer player;
        public GameObject playButton;
        public GameObject pauseButton;
        public GameObject videoObject;
        public Sprite thumbnail;
        public GameObject start;
        public GameObject end;
        public GameObject moving;
        private float xDist;
        private bool playing = false;

        public void Start()
        {
            moving.transform.position = start.transform.position;
            xDist = end.transform.position.x - start.transform.position.x;
            player.Pause();
            //player.Prepare();
           // player.frame = (long)((float)player.clip.frameCount * 0.01);

        }
        private void Update()
        {
            if (player.isPlaying)
            {
                float progress = (float)player.frame / (float)player.clip.frameCount;
                moving.transform.position = new Vector3(start.transform.position.x + progress * xDist, moving.transform.position.y);
            }
        }
        public void MovingPressed()
        {
            player.Pause();
        }
        public void MovingDragged(float xPos)
        {
            if (xPos > end.transform.position.x)
                moving.transform.position = end.transform.position;
            else
            {
                if (xPos < start.transform.position.x)
                    moving.transform.position = start.transform.position;
                else
                {
                    moving.transform.position = new Vector3(xPos, moving.transform.position.y);
                }
            }
            float dist = moving.transform.position.x - start.transform.position.x;
            float percentage = dist / xDist;
            player.frame = (long)((float)player.clip.frameCount * (float)percentage);
        }
        public float ReturnProgress()
        {
            return player.frame / (float)player.clip.frameCount;
        }
        public void MovingReleased()
        {
            if (playing)
                player.Play();
        }
        public void Play()
        {
            playing = true;
            player.Play();
            playButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        public void Pause()
        {
            playing = false;
            player.Pause();
            pauseButton.SetActive(false);
            playButton.SetActive(true);
        }
        public void Stop()
        {
            playing = false;
            player.Stop();
            pauseButton.SetActive(false);
            playButton.SetActive(true);
            moving.transform.position = start.transform.position;
            
        }


    }
}