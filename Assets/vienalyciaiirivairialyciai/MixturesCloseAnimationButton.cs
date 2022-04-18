using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesCloseAnimationButton : MonoBehaviour
{
    public MixturesAbstractAnim Animation;
    private void OnMouseDown()
    {
        Animation.StopAnimation();
    }
}
