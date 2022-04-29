using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeCont6 : MonoBehaviour
{
    public GameObject SingleSmall;
    public GameObject SingleLarge;
    public GameObject BottomLeft;
    public GameObject TopRight;
    public GameObject[] SpawnedSmall = new GameObject[20];
    public GameObject[] SpawnedLarge = new GameObject[2];
    public MicroscopeTracker TopTracker;
    public MicroscopeTracker BotTracker;
    private void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            float x = Random.Range(BottomLeft.transform.position.x, TopRight.transform.position.x);
            float y = Random.Range(BottomLeft.transform.position.y, TopRight.transform.position.y);
            SpawnedLarge[i] = Instantiate(SingleLarge, new Vector3(x, y), new Quaternion(), this.transform);
            SpawnedLarge[i].GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 5;
            SpawnedLarge[i].GetComponent<MicroscopeParticle>().SetNum(i + 1);
        }
      //  TopTracker.Particle = SpawnedLarge[0].GetComponent<MicroscopeParticle>();
      //  BotTracker.Particle = SpawnedLarge[1].GetComponent<MicroscopeParticle>();
        for (int i = 0; i < 20; i++)
        {
            float x = Random.Range(BottomLeft.transform.position.x, TopRight.transform.position.x);
            float y = Random.Range(BottomLeft.transform.position.y, TopRight.transform.position.y);
            SpawnedSmall[i] = Instantiate(SingleSmall, new Vector3(x, y), new Quaternion(), this.transform);
            SpawnedSmall[i].GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 5;
        }
    }
}
