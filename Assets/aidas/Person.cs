using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aidas;
namespace Aidas
{
    public class Person : MonoBehaviour
    {
        public GameObject idle;
        public GameObject animationObj;
        public void PlayAnimation()
        {

            StartCoroutine(Animation());

        }
        IEnumerator Animation()
        {
            idle.SetActive(false);
            animationObj.SetActive(true);
            Animator anim = animationObj.GetComponentInChildren<Animator>();
            anim.enabled = true;
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            animationObj.SetActive(false);
            idle.SetActive(true);
        }
    }
}
