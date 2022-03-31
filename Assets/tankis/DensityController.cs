using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace tankis
{
    public class DensityController : MonoBehaviour
    {
        public GameObject movingTop;
        public GameObject movingBot;
        public GameObject TopEnd;
        public GameObject BotEnd;
        public GameObject TopStart;
        public GameObject BotStart;
        public int MassStart;
        public int MassEnd;
        public int VolumeStart;
        public int VolumeEnd;
        public TextMeshPro[] MassText;
        public TextMeshPro VolumeText;
        float xDist;
        public GameObject Cube;
        public GameObject CubeSmall;
        public GameObject CubeLarge;
        public Sprite Lead;
        public Sprite Aluminum;
        public Sprite Wood;
        public void SetMaterial(int num)
        {
            switch (num)
            {
                case 0:
                    MassStart = 113;
                    MassEnd = 1130;
                    VolumeStart = 10;
                    VolumeEnd = 100;
                    Cube.GetComponent<SpriteRenderer>().sprite = Lead;
                    break;
                case 1:
                    MassStart = 27;
                    MassEnd = 270;
                    VolumeStart = 10;
                    VolumeEnd = 100;
                    Cube.GetComponent<SpriteRenderer>().sprite = Aluminum;
                    break;
                case 2:
                    MassStart = 6;
                    MassEnd = 60;
                    VolumeStart = 10;
                    VolumeEnd = 100;
                    Cube.GetComponent<SpriteRenderer>().sprite = Wood;
                    break;
            }
            MovingDragged(movingTop.transform.position.x);
        }
        private void Start()
        {
            xDist = TopEnd.transform.position.x - TopStart.transform.position.x;
        }
        public void MovingDragged(float xPos)
        {
            if (xPos > TopEnd.transform.position.x)
            {
                movingTop.transform.position = TopEnd.transform.position;
                movingBot.transform.position = BotEnd.transform.position;
            }
            else
            {
                if (xPos < TopStart.transform.position.x)
                {
                    movingTop.transform.position = TopStart.transform.position;
                    movingBot.transform.position = BotStart.transform.position;
                }
                else
                {
                    movingTop.transform.position = new Vector3(xPos, movingTop.transform.position.y);
                    movingBot.transform.position = new Vector3(xPos, movingBot.transform.position.y);
                }
            }
            float dist = movingTop.transform.position.x - TopStart.transform.position.x;
            float percentage = dist / xDist;
            int mass = Mathf.RoundToInt((MassEnd - MassStart) * percentage + MassStart);
            int volume = Mathf.RoundToInt((VolumeEnd - VolumeStart) * percentage + VolumeStart);
            SetText(mass, MassText[0]);
            SetText(mass, MassText[1]);
            SetText(volume, VolumeText);
            SetCube(percentage);
        }
        void SetText(int number, TextMeshPro text)
        {
            string full = (number / 10).ToString();
            string part = (number % 10).ToString();
            text.text = string.Format("{0},{1}", full, part);
        }
        void SetCube(float percent)
        {
            float yPos = (CubeLarge.transform.position.y - CubeSmall.transform.position.y) * percent + CubeSmall.transform.position.y;
            Cube.transform.position = new Vector3(Cube.transform.position.x, yPos);
            Cube.transform.localScale = new Vector3(1 + percent, 1 + percent);
        }
    }
}