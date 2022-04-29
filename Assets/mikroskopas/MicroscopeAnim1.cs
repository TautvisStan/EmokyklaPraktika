using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroscopeAnim1 : MonoBehaviour
{
    public GameObject[] Buttons;
    public Animator ImageAnim;
    private void Start()
    {
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(ImageAnim.GetCurrentAnimatorStateInfo(0).length);
        foreach (GameObject obj in Buttons)
        {
            obj.SetActive(true);
        }
    }
}
