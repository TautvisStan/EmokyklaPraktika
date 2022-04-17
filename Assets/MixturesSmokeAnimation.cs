using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesSmokeAnimation : MixturesAbstractAnim
{
    public GameObject AnimationWindow;
    public GameObject Part0;
    public GameObject Part1;
    public GameObject Part2;
    public GameObject Part3;
    public MixturesGreyButton Months;
    public int FakeTime = 7;
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
        Months.ReloadGreyButton();
        AnimationWindow.SetActive(false);
        Part3.SetActive(false);
        Part2.SetActive(false);
        Part1.SetActive(false);
        Part0.SetActive(false);
    }
    IEnumerator MainAnimation()
    {
        Part0.SetActive(true);
        yield return new WaitForSeconds(1f);
        Part1.SetActive(true);
        SetFadeIn(Part1);
        yield return new WaitForSeconds(2f);
        while(timerFrame != FakeTime)
        {
            timerFrame++;
            Months.MonthsText.text = "0" + timerFrame.ToString();
            if(timerFrame == 3)
            {
                Part2.SetActive(true);
                SetFadeIn(Part2);
            }
            if (timerFrame == 6)
            {
                Part3.SetActive(true);
                SetFadeIn(Part3);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void SetFadeIn(GameObject obj)
    {
        Keyframe[] alpha = new Keyframe[2];
        alpha[0] = new Keyframe(0, 0);
        alpha[1] = new Keyframe(0.5f, 1);
        AnimationCurve alphac = new AnimationCurve(alpha);
        AnimationClip clip = new AnimationClip();
        clip.SetCurve("", typeof(SpriteRenderer), "m_Color.a", alphac);
        clip.legacy = true;
        Animation anim = obj.GetComponent<Animation>();
        anim.AddClip(clip, "animation");
        anim.Play("animation");
    }
}
