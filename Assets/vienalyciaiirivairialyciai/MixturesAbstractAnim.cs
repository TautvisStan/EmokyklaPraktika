using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MixturesAbstractAnim : MonoBehaviour
{
    public bool running = false;
    public abstract void StartAnimation();
    public abstract void StopAnimation();
}
