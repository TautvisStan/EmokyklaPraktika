using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingFlowerImage : MonoBehaviour
{
    public GameObject LeftSide;
    public GameObject RightSide;
    public GameObject CenterSide;
    public GameObject SmallImage;
    public GameObject LargeImage;
    public UIBlur BlurImage;
    bool rightSide;
    float xDist;
    float scaleDiff;
    Vector3 correctScale;
    void Start()
    {
        correctScale = SmallImage.transform.localScale;
    }
    public void SetLeftPos()
    {
        transform.position = LeftSide.transform.position;
        rightSide = false;
        xDist = CenterSide.transform.position.x - LeftSide.transform.position.x;
    }
    public void SetRightPos()
    {
        transform.position = RightSide.transform.position;
        rightSide = true;
        xDist = RightSide.transform.position.x - CenterSide.transform.position.x;
    }
    public void SetScale(float a, float b)
    {
        float scaletest = LargeImage.transform.localScale.x * a / b;
        correctScale = new Vector3(scaletest, scaletest);
        transform.localScale = correctScale;
        if (rightSide)
        {

            transform.localScale = new Vector3(transform.localScale.x * 1.23f, transform.localScale.y * 1.23f);
            scaleDiff = transform.localScale.x - correctScale.x;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * 1/1.3f, transform.localScale.y * 1/1.3f);
            scaleDiff = correctScale.x - transform.localScale.x;
        }
    }
    private void Update()
    {
        UpdatePosition(BlurImage.Intensity);
        UpdateScale(BlurImage.Intensity);
    }
    public void UpdateScale(float percentage)
    {
        if(!rightSide)
        {
            transform.localScale = new Vector3(correctScale.x - scaleDiff * percentage, correctScale.y - scaleDiff * percentage);
        }
        else
        {
            transform.localScale = new Vector3(correctScale.x + scaleDiff * percentage, correctScale.y + scaleDiff * percentage);
        }
    }
    public void UpdatePosition(float percentage)
    {
        if(!rightSide)
        {
            transform.position = new Vector3(CenterSide.transform.position.x - xDist * percentage, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(CenterSide.transform.position.x + xDist * percentage, transform.position.y);
        }
    }
}
