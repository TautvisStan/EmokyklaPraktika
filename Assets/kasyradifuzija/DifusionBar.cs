using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionBar : MonoBehaviour
{
    public GameObject start;
    public GameObject end;
    public GameObject mid;
    public GameObject moving;
    public SpriteRenderer Highlight;
    public Sprite Top;
    public Sprite Mid;
    public Sprite Bot;
    private float yDist;
    string Position;
    public DifusionController2 main;
    public string mode;
    public void Start()
    {
        yDist = System.Math.Abs(end.transform.position.y - start.transform.position.y);

    }
    public void ResetBar()
    {
        moving.transform.position = mid.transform.position;
        Position = "Mid";
    }
    public void Pressed()
    {
        main.ResetBars(this);
        Highlight.gameObject.SetActive(true);
    }
    public void Released()
    {
        Highlight.gameObject.SetActive(false);
        switch (Position)
        {
            case "Top":
                moving.transform.position = start.transform.position;
                break;
            case "Mid":
                moving.transform.position = mid.transform.position;
                break;
            case "Bot":
                moving.transform.position = end.transform.position;
                break;
        }
        main.SpawnParticles(mode, Position);
    }
    public void MovingDragged(float yPos)
    {
        if (yPos < end.transform.position.y)
            moving.transform.position = end.transform.position;
        else
        {
            if (yPos > start.transform.position.y)
                moving.transform.position = start.transform.position;
            else
            {
                moving.transform.position = new Vector3(moving.transform.position.x, yPos);
            }
        }
        float dist = System.Math.Abs(moving.transform.position.y - start.transform.position.y);
        float percentage = dist / yDist;
        if (percentage < 0.33)
        {
            Highlight.sprite = Top;
            Position = "Top";
        }
        if (percentage >= 0.33 && percentage < 0.67)
        {
            Highlight.sprite = Mid;
            Position = "Mid";
        }
        if (percentage >= 0.67)
        {
            Highlight.sprite = Bot;
            Position = "Bot";
        }
    }
}
