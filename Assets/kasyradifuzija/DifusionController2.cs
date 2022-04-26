using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionController2 : MonoBehaviour
{
    public DifusionBar[] Bars;
    public int ParticlesCount = 38;
    public GameObject[] BlueParticles;
    public GameObject[] YellowParticles;
    public GameObject BarrierTop;
    public GameObject BarrierMid;
    public GameObject BarrierBot;
    public GameObject Barrier;
    public GameObject BotLeftBlue;
    public GameObject TopRightBlue;
    public GameObject BotLeftYellow;
    public GameObject TopRightYellow;
    public GameObject SingleBlue;
    public GameObject SingleYellow;
    public void ResetBars(DifusionBar currentBar)
    {
        Barrier.transform.position = BarrierMid.transform.position;
        foreach(DifusionBar bar in Bars)
        {
            if(bar != currentBar)
            {
                bar.ResetBar();
            }
        }
        foreach(GameObject obj in BlueParticles)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in YellowParticles)
        {
            Destroy(obj);
        }
    }
    public void SpawnParticles(string mode, string pos)
    {
        Barrier.transform.position = BarrierMid.transform.position;
        if (mode == "Gap")
        {
            if(pos == "Top")
            {
                Barrier.transform.position = BarrierTop.transform.position;
            }
            if (pos == "Bot")
            {
                Barrier.transform.position = BarrierBot.transform.position;
            }
        }
        float countMult = 1;
        if (mode == "Conc")
        {
            if (pos == "Top")
            {
                countMult = 2f;
            }
            if (pos == "Bot")
            {
                countMult = 0.5f;
            }
        }
        float speedMult = 1;
        if (mode == "Temp")
        {
            if (pos == "Top")
            {
                speedMult = 2f;
            }
            if (pos == "Bot")
            {
                speedMult = 0.5f;
            }
        }
        BlueParticles = new GameObject[(int)(ParticlesCount * countMult)];
        YellowParticles = new GameObject[(int)(ParticlesCount * countMult)];
        for (int i = 0; i < ParticlesCount * countMult; i++)
        {
            float x = Random.Range(BotLeftBlue.transform.position.x, TopRightBlue.transform.position.x);
            float y = Random.Range(BotLeftBlue.transform.position.y, TopRightBlue.transform.position.y);
            BlueParticles[i] = Instantiate(SingleBlue, new Vector3(x, y), new Quaternion(), this.transform);
            BlueParticles[i].SetActive(true);
            BlueParticles[i].GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speedMult;
            x = Random.Range(BotLeftYellow.transform.position.x, TopRightYellow.transform.position.x);
            y = Random.Range(BotLeftYellow.transform.position.y, TopRightYellow.transform.position.y);
            YellowParticles[i] = Instantiate(SingleYellow, new Vector3(x, y), new Quaternion(), this.transform);
            YellowParticles[i].SetActive(true);
            YellowParticles[i].GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speedMult;
        }
    }
}
