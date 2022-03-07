using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aidas;
namespace Aidas
{
    public class Sounds : MonoBehaviour
    {
        public GameObject Sound1;
        public GameObject Echo1;
        public GameObject Sound2;
        public GameObject Echo2;
        public void PlayAnimation(int num)
        {

            StartCoroutine(Animation(num));

        }
        IEnumerator Animation(int num)
        {
            Animator anim = null;
            switch (num)
            {
                case 1:
                    Sound1.SetActive(true);
                    anim = Sound1.GetComponentInChildren<Animator>();
                    anim.enabled = true;
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                    anim.enabled = false;
                    Sound1.SetActive(false);
                    break;
                case 2:
                    Echo1.SetActive(true);
                    anim = Echo1.GetComponentInChildren<Animator>();
                    anim.enabled = true;
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                    anim.enabled = false;
                    Echo1.SetActive(false);
                    break;
                case 3:
                    Sound2.SetActive(true);
                    anim = Sound2.GetComponentInChildren<Animator>();
                    anim.enabled = true;
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                    anim.enabled = false;
                    Sound2.SetActive(false);
                    break;
                case 4:
                    Echo2.SetActive(true);
                    anim = Echo2.GetComponentInChildren<Animator>();
                    anim.enabled = true;
                    yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                    anim.enabled = false;
                    Echo2.SetActive(false);
                    break;
            }

        }
    }
}
