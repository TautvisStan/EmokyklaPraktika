using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeFrameClose : MonoBehaviour
{
    public MicroscopeTracker TopTracker;
    public MicroscopeTracker BotTracker;
    public GameObject Frame;
    public MicroscopeCont6 main;
    public MicroscopeTrajectory Button;
    private void OnMouseDown()
    {
        Frame.SetActive(false);
        TopTracker.Particle = null;
        TopTracker.GetComponent<LineRenderer>().positionCount = 0;
        BotTracker.Particle = null;
        BotTracker.GetComponent<LineRenderer>().positionCount = 0;
        Button.GetComponent<BoxCollider2D>().enabled = true;
        Button.GetComponent<SpriteRenderer>().sprite = Button.Default;
    }
}
