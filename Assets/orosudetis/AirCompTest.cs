using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class AirCompTest : MonoBehaviour
{
    public Vector3[] points;
    public Vector3[] placedPoints;
    public LineRenderer lineRenderer;
    public int maxToPlace;
    public float distance;
    public float placeDist;
    public GameObject routeNode;
    private void OnEnable()
    {
        calc();
        spawn();
    }
    public void calc()
    {
        distance = 0;
        points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points);
        //   placedPoints = new GameObject[maxToPlace];
        placedPoints = new Vector3[maxToPlace];
        for (int i = 0; i < points.Length-1; i++)
        {
            distance += Vector3.Distance(points[i], points[i + 1]);
        }
        placeDist = distance / maxToPlace;
    }
    public void spawn()
    {

        // placedPoints[0] = Instantiate(routeNode, points[0], new Quaternion());
        placedPoints[0] = points[0];
        Vector3 pos = points[0];
        Vector3 nextDirection = points[1] - points[0];
        int nextPoint = 1;
        for (int i = 1; i < maxToPlace; i++)
        {
            float remainingDist = placeDist;
            while(!EnoughDistance(ref remainingDist, ref nextDirection,ref nextPoint,ref pos));
            //     placedPoints[i] = Instantiate(routeNode, pos, new Quaternion());
            placedPoints[i] = pos;
        }
       
    }
    bool EnoughDistance(ref float remainingDist, ref Vector3 nextDirection, ref int nextPoint, ref Vector3 pos)
    {
        if (nextDirection.magnitude >= remainingDist)
        {
            pos += nextDirection.normalized * remainingDist;
            nextDirection = points[nextPoint] - pos;
            remainingDist = placeDist;
            return true;
        }
        else
        {
            remainingDist -= nextDirection.magnitude;
            pos = points[nextPoint];
            nextPoint++;
            nextDirection = points[nextPoint] - pos;
            
            return false;
        }
    }
}
