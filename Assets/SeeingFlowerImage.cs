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
    public void SetScale(float percentage)
    {
        float scaleDif = LargeImage.transform.localScale.x - SmallImage.transform.localScale.x;
        transform.localScale = new Vector3(SmallImage.transform.localScale.x + scaleDif * percentage, SmallImage.transform.localScale.y + scaleDif * percentage);
    }
    private void Update()
    {
        UpdatePosition(BlurImage.Intensity);
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
