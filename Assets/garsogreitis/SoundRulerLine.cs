using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundRulerLine : MonoBehaviour
{
    LineRenderer Line;
    public GameObject LineStart;
    public GameObject LineEnd;
    public TextMeshPro DistanceText;
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        UpdateLine();
    }

    public void UpdateLine()
    {
        Line.SetPosition(0, LineStart.transform.position);
        Line.SetPosition(1, LineEnd.transform.position);
        float dist = Vector2.Distance(LineStart.transform.position, LineEnd.transform.position) / 1.68f;
        dist = (float)System.Math.Round((decimal)dist, 2);
        string text = dist.ToString() + " m";
        DistanceText.text = text;
    }
}
