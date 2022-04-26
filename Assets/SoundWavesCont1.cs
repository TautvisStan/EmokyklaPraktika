using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWavesCont1 : MonoBehaviour
{
    public GameObject UndergroundWave;
    public GameObject AboveWave;
    public GameObject SpawnPos;
    public GameObject Voice1;
    public GameObject Voice2;
    float timer = 0f;
    public float VoiceTimer1;
    public float VoiceTimer2;
    private void FixedUpdate()
    {
        if(timer <= 0f)
        {
            GameObject obj = Instantiate(UndergroundWave, SpawnPos.transform.position, new Quaternion(), this.transform);
            obj.SetActive(true);
            obj = Instantiate(AboveWave, SpawnPos.transform.position, new Quaternion(), this.transform);
            obj.SetActive(true);
            timer += 2f;
        }
        else
        {
            timer -= Time.fixedDeltaTime;
        }
        if (!Voice1.activeSelf)
        {
            if (VoiceTimer1 > 0)
            {
                VoiceTimer1 -= Time.fixedDeltaTime;
            }
            else
            {
                Voice1.SetActive(true);
            }
        }
        if (!Voice2.activeSelf)
        {
            if (VoiceTimer2 > 0)
            {
                VoiceTimer2 -= Time.fixedDeltaTime;
            }
            else
            {
                Voice2.SetActive(true);
            }
        }
    }
}
