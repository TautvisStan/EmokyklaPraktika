using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingSoundwave : MonoBehaviour
{
    SpriteRenderer image;
    bool paused = false;
    public int positionInQueue;
    private void Start()
    {
        positionInQueue *= -1;
        image = GetComponent<SpriteRenderer>();
    }
    public void test()
    {
        StartCoroutine(DoCheck());
    }
    public void PauseWave()
    {
        StopAllCoroutines();
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            if (!paused)
            {
                if (positionInQueue == 0)
                {
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                }
                positionInQueue++;
                if (positionInQueue == 5)
                {
                    positionInQueue = 0;
                }

                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
