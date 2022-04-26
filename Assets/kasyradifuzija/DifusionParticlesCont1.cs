using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionParticlesCont1 : MonoBehaviour
{
    public GameObject[] BlueParticles;
    public GameObject[] YellowParticles;
    public DifusionWindowButton Button;
    public GameObject Text3;
    public GameObject BottomText;
    bool paused = false;
    public void StartAnimation()
    {
        StartBlue();
        StartCoroutine(StartAnim());
    }
    void StartBlue()
    {
        foreach(GameObject obj in BlueParticles)
        {
            obj.SetActive(true);
            obj.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized;
        }
    }
    public void PauseWindow()
    {
        paused = true;
        foreach (GameObject obj in BlueParticles)
        {
            obj.GetComponent<DifusionParticle1>().PauseParticle();
        }
        foreach (GameObject obj in YellowParticles)
        {
            obj.GetComponent<DifusionParticle1>().PauseParticle();
        }
    }
    public void ResumeWindow()
    {
        
        foreach (GameObject obj in BlueParticles)
        {
            obj.GetComponent<DifusionParticle1>().ResumeParticle();
        }
        foreach (GameObject obj in YellowParticles)
        {
            obj.GetComponent<DifusionParticle1>().ResumeParticle();
        }
        paused = false;
    }
    public void RestartWindow()
    {
        Text3.SetActive(false);
        BottomText.SetActive(false);
        foreach (GameObject obj in BlueParticles)
        {
            obj.GetComponent<DifusionParticle1>().ResetParticle();
            obj.SetActive(false);
        }
        foreach (GameObject obj in YellowParticles)
        {
            obj.GetComponent<DifusionParticle1>().ResetParticle();
            obj.SetActive(false);
        }
    }
    IEnumerator StartAnim()
    {
        paused = false;
        foreach (GameObject obj in YellowParticles)
        {
            float time1 = 0.25f;
            float passed1 = 0;
            while (passed1 < time1)
            {
                while (paused) yield return null;
                passed1 += Time.deltaTime;
                yield return null;
            }
            obj.SetActive(true);
            SetFadeIn(obj);
            obj.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized;
        }
        Text3.SetActive(true);
        BottomText.SetActive(true);
        float time = 5f;
        float passed = 0;
        while (passed < time)
        {
            while(paused) yield return null;
            passed += Time.deltaTime;
            yield return null;
        }
        PauseWindow();
        Button.SetRestart();
    }
    void SetFadeIn(GameObject obj)
    {
        Keyframe[] alpha = new Keyframe[2];
        alpha[0] = new Keyframe(0, 0);
        alpha[1] = new Keyframe(1f, 1f);
        AnimationCurve alphac = new AnimationCurve(alpha);
        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(SpriteRenderer), "m_Color.a", alphac);
        clip.legacy = true;
        Animation anim = obj.GetComponent<Animation>();
        anim.AddClip(clip, "animation");
        anim.Play("animation");
    }
}
