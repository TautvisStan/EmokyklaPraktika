using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeTrajectory : MonoBehaviour
{
    public MicroscopeTracker TopTracker;
    public MicroscopeTracker BotTracker;
    public GameObject Frame;
    public MicroscopeCont6 main;
    public Sprite Selected;
    public Sprite Default;
    private void OnMouseDown()
    {
        Frame.SetActive(true);
        TopTracker.Particle = main.SpawnedLarge[0].GetComponent<MicroscopeParticle>();
        BotTracker.Particle = main.SpawnedLarge[1].GetComponent<MicroscopeParticle>();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = Selected;
    }
}
