using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifusionParticle1 : MonoBehaviour
{
    Vector3 startingPos;
    Vector3 velocity;
    private void Start()
    {
        startingPos = transform.position;
    }
    public void PauseParticle()
    {
        velocity = GetComponent<Rigidbody2D>().velocity;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }
    public void ResumeParticle()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public void ResetParticle()
    {
        transform.position = startingPos;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
