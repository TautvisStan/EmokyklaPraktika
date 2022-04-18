using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesMilkAnimation : MixturesAbstractAnim
{
    public GameObject AnimationWindow;
    public GameObject FirstPart;
    public GameObject SecondPart;
    public GameObject ThirdPart;
    public GameObject BottomLeftCorner;
    public GameObject TopRightCorner;
    public GameObject MilkParticle;
    public GameObject[] SpawnedParticles = new GameObject[180];
    int spawned = 0;
    public MixturesGreyButton Timer;
    public float RealTime = 60f;
    public int FakeTime = 480;
    int timerFrame = 0;
    public override void StartAnimation()
    {
        running = true;
        AnimationWindow.SetActive(true);
        StartCoroutine(MainAnimation());
    }
    public override void StopAnimation()
    {
        StopAllCoroutines();
        running = false;
        timerFrame = 0;
        Timer.ReloadGreyButton();
        AnimationWindow.SetActive(false);
        SecondPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        ThirdPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        for (int i = 0; i < spawned; i++)
        {
            Destroy(SpawnedParticles[i]);
        }
        spawned = 0;
    }
    IEnumerator MainAnimation()
    {
        int particleLayer = MilkParticle.GetComponent<SpriteRenderer>().sortingOrder;
        while (timerFrame != FakeTime)
        {
            timerFrame++;
            int timerH = timerFrame / 60;
            int timerM = timerFrame % 60;
            string timerHString;
            string timerMString;
            if (timerH < 10)
            {
                timerHString = "0" + timerH.ToString();
            }
            else
            {
                timerHString = timerH.ToString();
            }
            if (timerM < 10)
            {
                timerMString = "0" + timerM.ToString();
            }
            else
            {
                timerMString = timerM.ToString();
            }
            Timer.TimerText.text = timerHString + ":" + timerMString;
            if(timerFrame < 240)
            {
                SecondPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, timerFrame / 240f);
            }
            if (timerFrame >= 240 && timerFrame < 480)
            {
                ThirdPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame-240) / 240f);
            }
            if (timerFrame % 3 == 0)
            {
                float x = Random.Range(BottomLeftCorner.transform.position.x, TopRightCorner.transform.position.x);
                float y = Random.Range(BottomLeftCorner.transform.position.y, TopRightCorner.transform.position.y);
                SpawnedParticles[spawned] = Instantiate(MilkParticle, new Vector3(x, y), new Quaternion());
                SpawnedParticles[spawned].transform.localScale = new Vector3(0, 0);
                SpawnedParticles[spawned].GetComponent<SpriteRenderer>().sortingOrder = ++particleLayer;
                float scale;
                float time;
                if (spawned < 40)
                {
                    scale = 0.5f;
                    time = 0.5f;
                }
                else if (spawned < 60)
                {
                    scale = 0.8f;
                    time = 0.8f;
                }
                else if (spawned < 80)
                {
                    scale = 1f;
                    time = 1f;
                }
                else
                {
                    scale = 1.3f;
                    time = 1.3f;
                }
                Keyframe[] scax = new Keyframe[2];
                scax[0] = new Keyframe(0, 0);
                scax[1] = new Keyframe(time, scale);
                Keyframe[] scay = new Keyframe[2];
                scay[0] = new Keyframe(0, 0);
                scay[1] = new Keyframe(time, scale);
                AnimationCurve animx = new AnimationCurve(scax);
                AnimationCurve animy = new AnimationCurve(scay);
                AnimationClip clip = new AnimationClip();
                clip.SetCurve("", typeof(Transform), "localScale.x", animx);
                clip.SetCurve("", typeof(Transform), "localScale.y", animy);
                clip.legacy = true;
                Animation anim = SpawnedParticles[spawned].GetComponent<Animation>();
                anim.AddClip(clip, "animation");
                anim.Play("animation");
                spawned++;
            }
            yield return new WaitForSeconds(1 / (FakeTime / RealTime));
        }
    }
}
