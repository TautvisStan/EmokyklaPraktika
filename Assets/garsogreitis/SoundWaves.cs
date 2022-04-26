using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundWaves : MonoBehaviour
{
    LineRenderer line;
    float radius = 0f;
    public bool Underground;
    public float Speed;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        GoUp();
    }
    private void FixedUpdate()
    {
        radius += Speed;
        if(Underground)
        {
            GoDown();
        }
        else
            GoUp();
        if (radius >= 23f)
            Destroy(this.gameObject);
    }
    public void GoUp()
    {
        bool yGoingDown = true;
        float lineWidth = 0.1f;
        int segments = 720;
        line.useWorldSpace = true;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        int pointCount = segments + 1;
        Vector3[] points = new Vector3[pointCount];
        List<Vector3> RightSide = new List<Vector3>();
        List<Vector3> LeftSide = new List<Vector3>();
        for (int i = 0; i < pointCount; i++)
        {
            float rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius + transform.position.x, Mathf.Cos(rad) * radius + transform.position.y, 0);
            if (points[i].y >= -4.85f)
            {
                if (i == 0)
                {
                    RightSide.Add(points[i]);
                }
                else
                {
                    if (points[i-1].y  <= points[i].y)
                    {
                        yGoingDown = false;
                    }
                    if (yGoingDown)
                        RightSide.Add(points[i]);
                    else
                        LeftSide.Add(points[i]);
                }
            }
        }
        LeftSide.AddRange(RightSide);
        line.positionCount = LeftSide.Count;
        line.SetPositions(LeftSide.ToArray());
    }
    public void GoDown()
    {
        float lineWidth = 0.1f;
        int segments = 720;
        line.useWorldSpace = true;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        int pointCount = segments + 1; 
        Vector3[] points = new Vector3[pointCount];
        List<Vector3> test = new List<Vector3>();
        for (int i = 0; i < pointCount; i++)
        {
            float rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius + transform.position.x, Mathf.Cos(rad) * radius + transform.position.y, 0);
            if(points[i].y < -4.85f)
            {
                test.Add(points[i]);
            }
        }
        line.positionCount = test.Count;
        line.SetPositions(test.ToArray());
    }
}
