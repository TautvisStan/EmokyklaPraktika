using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DensityParticle : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Animator>().Play("New Animation", -1, Random.Range(0.0f, 1.0f));
    }

}
