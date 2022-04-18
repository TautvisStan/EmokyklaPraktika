using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixturesPaintAnimation : MixturesAbstractAnim
{
    public GameObject AnimationWindow;
    public GameObject AnimationPart1;
    public GameObject AnimationPart2;
    public GameObject Jar1;
    public GameObject Jar2;
    public GameObject Jar3;
    public GameObject Circle0;
    public GameObject Circle1;
    public GameObject Circle2;
    public GameObject Circle3;
    public GameObject Water;
    public GameObject Paint;
    public GameObject Image;
    public MixturesGreyButton Timer;
    public float RealTime = 25f;
    public int FakeTime = 240;
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
        AnimationPart1.SetActive(false);
        AnimationPart2.SetActive(false);
        Water.GetComponent<Animator>().enabled = false;
        Paint.GetComponent<Animator>().enabled = false;
        Image.GetComponent<Animator>().enabled = false;
        Circle1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Circle2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Circle3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Jar2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        Jar3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        AnimationWindow.SetActive(false);

    }
    IEnumerator MainAnimation()
    {
        AnimationPart1.SetActive(true);
        Water.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1.2f);
        Paint.GetComponent<Animator>().enabled = true;
        Image.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(5f);
        Timer.TimerText.text = "00:01";
        yield return new WaitForSeconds(5f);
        AnimationPart1.SetActive(false);
        AnimationPart2.SetActive(true);
        timerFrame = 30;
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
            if (timerFrame <=60)
            {
                Circle1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame - 30) / 30f);
                Jar2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame - 30) / 30f);
            }
            if (timerFrame == 60)
                timerFrame = 120;
            if (timerFrame > 120 && timerFrame <= 150)
            {
                Circle2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame - 120) / 30f);
                Jar3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame - 120) / 30f);
            }
            if (timerFrame > 150 && timerFrame <= 180)
            {
                Circle3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (timerFrame - 150) / 30f);
            }
            yield return new WaitForSeconds(1 / ((FakeTime-30) / RealTime));
        }

    }    
}
