using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountedCircle : MonoBehaviour
{
    public GameObject Idle;
    public GameObject SpeedingUp;
    public GameObject SlowingDown;
    public void Activate()
    {
        Idle.SetActive(true);
        Idle.GetComponent<Animator>().enabled = true;
        Animator anim = Idle.GetComponentInChildren<Animator>();
        anim.enabled = true;
    }
    public void Spinning()
    {
        Idle.SetActive(false);
        SlowingDown.SetActive(false);
        SpeedingUp.SetActive(true);
        SpeedingUp.GetComponent<Animator>().enabled = true;
        Animator anim = SpeedingUp.GetComponentInChildren<Animator>();
        anim.enabled = true;
        //anim.Play("SpeedingUp");
    }
    public void Slowing()
    {
        SpeedingUp.SetActive(false);
        SlowingDown.SetActive(true);
        SlowingDown.GetComponent<Animator>().enabled = true;
        Animator anim = SlowingDown.GetComponentInChildren<Animator>();
        anim.enabled = true;
        //anim.Play("SlowingDown");
    }
}
