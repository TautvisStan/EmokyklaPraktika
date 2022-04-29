using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeTracker : MonoBehaviour
{
    public MicroscopeParticle Particle;
    int pos = 0;
    private void FixedUpdate()
    {
        if (Particle != null)
        {
            GetComponent<LineRenderer>().positionCount = pos + 1;
            GetComponent<LineRenderer>().SetPosition(pos, Particle.transform.localPosition);
            pos++;
        }
        else
        {
            pos = 0;
        }
    }
}
