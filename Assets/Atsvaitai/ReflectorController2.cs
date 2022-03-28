using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atsvaitai
{
    public class ReflectorController2 : MonoBehaviour
    {
        public GameObject First;
        public GameObject Second;
        public GameObject ThirdIntro;
        public GameObject ThirdMain;

        public void ToSecond()
        {
            First.SetActive(false);
            Second.SetActive(true);
        }
        public void ToThird()
        {
            Second.SetActive(false);
            StartCoroutine(ThirdAnim());
        }
        IEnumerator ThirdAnim()
        {
            ThirdIntro.SetActive(true);
            Animator anim = ThirdIntro.GetComponentInChildren<Animator>();
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            ThirdIntro.SetActive(false);
            ThirdMain.SetActive(true);
        }
    }
}