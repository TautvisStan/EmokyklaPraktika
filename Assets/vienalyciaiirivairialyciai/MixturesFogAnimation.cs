using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesFogAnimation : MixturesAbstractAnim
{
    public GameObject AnimationWindow;
    public GameObject FirstPart;
    public GameObject SecondPart;
    public GameObject ThirdPart;
    public GameObject BottomLeftCorner;
    public GameObject TopRightCorner;
    public GameObject FogParticle;
    public GameObject[] SpawnedParticles = new GameObject[180];
    int spawned = 0;
    public MixturesGreyButton Timer;
    public float RealTime = 25f;
    public int FakeTime = 180;
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
        int particleLayer = FogParticle.GetComponent<SpriteRenderer>().sortingOrder;
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
            if (timerFrame < 60)
            {
                SecondPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, timerFrame / 60f);
            }
            if (timerFrame >= 60 && timerFrame < 120)
            {
                ThirdPart.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame - 60) / 60f);
            }
            if (timerFrame < 120)
            {
                float x = Random.Range(BottomLeftCorner.transform.position.x, TopRightCorner.transform.position.x);
                float y = Random.Range(BottomLeftCorner.transform.position.y, TopRightCorner.transform.position.y);
                SpawnedParticles[spawned] = Instantiate(FogParticle, new Vector3(x, y), new Quaternion());
                SpawnedParticles[spawned].transform.localScale = new Vector3(0, 0);
                SpawnedParticles[spawned].GetComponent<SpriteRenderer>().sortingOrder = ++particleLayer;
                float scale = 0;
                float time = 0;
                int particleSize = Random.Range(0, 3);
                switch(particleSize)
                {
                    case 0:
                        scale = 0.5f;
                        time = 2f;
                        break;
                    case 1:
                        scale = 0.8f;
                        time = 4f;
                        break;
                    case 2:
                        scale = 1f;
                        time = 8f;
                        break;
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
