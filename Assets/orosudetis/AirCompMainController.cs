using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AirCompMainController : MonoBehaviour
{
    public Vector3[] MovementNodes;
    public GameObject Person;
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
    public void MovingDragged(Vector3 mousePos)
    {
        if (currentNode != MovementNodes.Length - 1)
        {
            if (Vector2.Distance(mousePos, MovementNodes[currentNode + 1]) < 0.15)
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
        }
        else if (node >= 305)
        {
            DensityText.text = "0,59";
            HeightText.text = "7000";
        }
        else if (node >= 267)
        {
            DensityText.text = "0,66";
            HeightText.text = "6000";
        }
        else if (node >= 243)
        {
            DensityText.text = "0,74";
            HeightText.text = "5000";
        }
        else if (node >= 194)
        {
            DensityText.text = "0,82";
            HeightText.text = "4000";
        }
        else if (node >= 148)
        {
            DensityText.text = "0,91";
            HeightText.text = "3000";
        }
        else if (node >= 96)
        {
            DensityText.text = "1,00";
            HeightText.text = "2000";
        }
        else if (node >= 45)
        {
            DensityText.text = "1,11";
            HeightText.text = "1000";
        }
        else if (node == 1)
        {
            DensityText.text = "1,23";
            HeightText.text = "0";
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
}
