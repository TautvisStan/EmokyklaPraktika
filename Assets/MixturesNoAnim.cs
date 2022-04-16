using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesNoAnim : MixturesAbstractAnim
{
    public GameObject Text;
    public override void StartAnimation()
    {
        running = true;
        Text.SetActive(true);
    }
    public override void StopAnimation()
    {
        if (running)
        {
            running = false;
            Text.SetActive(false);
        }
    }
}
