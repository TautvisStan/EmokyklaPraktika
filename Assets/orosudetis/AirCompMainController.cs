using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AirCompMainController : MonoBehaviour
{
    public Vector3[] MovementNodes;
    public AirCompPerson Person;
    public GameObject[] N2Particles;
    public GameObject[] O2Particles;
    public float tankis_8000 = 0.53f;
    public float tankis_0 = 1.23f;
    public TextMeshPro DensityText;
    public TextMeshPro HeightText;
    public float yOffset = 1.265f;
    float n2_molekuliu_kiekis_8000;
    float o2_molekuliu_kiekis_8000;
    float n2_molekuliu_retejimas_kadrui;
    float o2_molekuliu_retejimas_kadrui;
    int N2Removed = 0;
    int O2Removed = 0;
    public AirCompTest Route;
    int currentNode = 0;
    public GameObject Window;
    public GameObject WindowSmall;
    public GameObject WindowLarge;
    public GameObject Text3000;
    public GameObject Text7000;
    public GameObject RedText;
    public GameObject GreenText;
    public TMP_InputField Input;
    public GameObject GoDownButton;
    private void Start()
    {
        MovementNodes = Route.placedPoints;
        Person.transform.position = MovementNodes[0] + new Vector3(0, yOffset, 0);
        n2_molekuliu_kiekis_8000 = (int)Math.Round(N2Particles.Length * tankis_8000 / tankis_0);
        o2_molekuliu_kiekis_8000 = (int)Math.Round(O2Particles.Length * tankis_8000 / tankis_0);
        n2_molekuliu_retejimas_kadrui = (N2Particles.Length - n2_molekuliu_kiekis_8000) / MovementNodes.Length;
        
        o2_molekuliu_retejimas_kadrui = (O2Particles.Length - o2_molekuliu_kiekis_8000) / MovementNodes.Length;
        for (int i = 0; i < N2Particles.Length - 1; i++)
        {
            int rnd = UnityEngine.Random.Range(i, N2Particles.Length);
            GameObject temp = N2Particles[rnd];
            N2Particles[rnd] = N2Particles[i];
            N2Particles[i] = temp;
        }
        for (int i = 0; i < O2Particles.Length - 1; i++)
        {
            int rnd = UnityEngine.Random.Range(i, O2Particles.Length);
            GameObject temp = O2Particles[rnd];
            O2Particles[rnd] = O2Particles[i];
            O2Particles[i] = temp;
        }
    }
    public void WindowClosed()
    {
        Person.EnableDragging();
    }
    public void MovingDragged(Vector3 mousePos)
    {
        if (currentNode != MovementNodes.Length - 1)
        {
            Vector2 pos = mousePos - new Vector3(0, yOffset, 0);
            if (System.Math.Abs(pos.y - MovementNodes[currentNode + 1].y) < 0.25)
            {
                currentNode++;
                Person.transform.position = MovementNodes[currentNode] + new Vector3(0, yOffset, 0);
                UpdateMovement(currentNode);
            }
        }
    }
    void UpdateMovement(int node)
    {
        node++;
        if (node == 330)
        {
            DensityText.text = "0,53";
            HeightText.text = "8000";
            Person.Set8000Sprite();
        }
        else if (node == 305)
        {
            DensityText.text = "0,59";
            HeightText.text = "7000";
            Person.DisableDragging();
            Window.SetActive(true);
            WindowLarge.SetActive(false);
            WindowSmall.SetActive(true);
            Text3000.SetActive(false);
            Text7000.SetActive(true);
            RedText.SetActive(false);
            GreenText.SetActive(false);
            Person.Set7000Sprite();

        }
        else if (node == 267)
        {
            DensityText.text = "0,66";
            HeightText.text = "6000";
        }
        else if (node == 243)
        {
            DensityText.text = "0,74";
            HeightText.text = "5000";
        }
        else if (node == 194)
        {
            DensityText.text = "0,82";
            HeightText.text = "4000";
        }
        else if (node == 145)
        {
            DensityText.text = "0,91";
            HeightText.text = "3000";
            Person.DisableDragging();
            Window.SetActive(true);
            WindowLarge.SetActive(true);
            WindowSmall.SetActive(false);
            Text3000.SetActive(true);
            Text7000.SetActive(false);
            RedText.SetActive(false);
            GreenText.SetActive(false);
            Person.Set3000Sprite();
            GoDownButton.SetActive(true);

        }
        else if (node == 96)
        {
            DensityText.text = "1,00";
            HeightText.text = "2000";
        }
        else if (node == 45)
        {
            DensityText.text = "1,11";
            HeightText.text = "1000";
        }
        else if (node == 1)
        {
            DensityText.text = "1,23";
            HeightText.text = "0";
            Person.Set0Sprite();
            GoDownButton.SetActive(false);
        }

        int N2ToRemove = (int)Math.Round(node * n2_molekuliu_retejimas_kadrui);
        while (N2Removed < N2ToRemove)
        {
            N2Particles[N2Removed].SetActive(false);
            N2Removed++;
        }
        int O2ToRemove = (int)Math.Round(node * o2_molekuliu_retejimas_kadrui);
        while (O2Removed < O2ToRemove)
        {
            O2Particles[O2Removed].SetActive(false);
            O2Removed++;
        }
    }
    public void CheckInput()
    {
        if(Input.text == "2,2" || Input.text == "2,3" || Input.text == "2,32")
        {
            Window.SetActive(true);
            WindowLarge.SetActive(false);
            WindowSmall.SetActive(true);
            Text3000.SetActive(false);
            Text7000.SetActive(false);
            RedText.SetActive(false);
            GreenText.SetActive(true);
        }
        else
        {
            Window.SetActive(true);
            WindowLarge.SetActive(false);
            WindowSmall.SetActive(true);
            Text3000.SetActive(false);
            Text7000.SetActive(false);
            RedText.SetActive(true);
            GreenText.SetActive(false);
        }
    }
    public void GoDown()
    {
        currentNode = 0;
        Person.transform.position = MovementNodes[currentNode] + new Vector3(0, yOffset, 0);
        UpdateMovement(currentNode);
        N2Removed = 0;
        foreach (GameObject obj in N2Particles)
        {
            obj.SetActive(true);
        }
        O2Removed = 0;
        foreach (GameObject obj in O2Particles)
        {
            obj.SetActive(true);
        }
    }
}
