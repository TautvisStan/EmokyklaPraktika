using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MicroscopeParticle : MonoBehaviour
{
    public int num;
    public TextMeshPro number;
    public void SetNum(int numb)
    {
        num = numb;
        number.text = num.ToString();
    }
}
