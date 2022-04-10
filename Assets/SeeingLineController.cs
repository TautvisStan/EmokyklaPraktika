using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SeeingLineController : MonoBehaviour
{
    public LineRenderer LeftLineTop;
    public LineRenderer LeftLineBot;
    public LineRenderer RightLineTop;
    public LineRenderer RightLineBot;
    public LineRenderer AcrossLineTop;
    public LineRenderer AcrossLineBot;
    public GameObject FlowerTop;
    public GameObject FlowerBot;
    public GameObject LensTop;
    public GameObject LensBot;
    public GameObject FlowerImageTop;
    public GameObject FlowerImageBot;
    
    public void OnEnable()
    {
        SetupLines();
    }
    private void FixedUpdate()
    {
        SetupLines();
    }
    public void SetupLines()
    {
        SingleLine(LeftLineTop, FlowerTop, LensTop);
        SingleLine(LeftLineBot, FlowerBot, LensBot);
        SingleLine(RightLineTop, LensTop, FlowerImageBot);
        SingleLine(RightLineBot, LensBot, FlowerImageTop);
        SingleLine(AcrossLineTop, FlowerTop, FlowerImageBot);
        SingleLine(AcrossLineBot, FlowerBot, FlowerImageTop);
    }
    public void SingleLine(LineRenderer line, GameObject pos1, GameObject pos2)
    {
        Vector3[] Positions = new Vector3[2];
        Positions[0] = pos1.transform.position;
        Positions[1] = pos2.transform.position;
        line.SetPositions(Positions);
    }
}
