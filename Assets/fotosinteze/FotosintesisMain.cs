using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace fotosinteze
{
    public class FotosintesisMain : MonoBehaviour
    {
        private int part = 1;
        public GameObject[] Parts;
        public Animator Part6Anim;
        public GameObject Part6Arrows;
        
        public void SetPart(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Parts[i].SetActive(true);
            }
            for (int i = num; i < Parts.Length; i++)
            {
                Parts[i].SetActive(false);
            }
            if (num == 6)
            {
                StartCoroutine(Animation());
            }
            else
            {
                Part6Anim.enabled = true;
                Part6Arrows.SetActive(false);
            }

        }
        IEnumerator Animation()
        {
            Part6Anim.enabled = true;
            yield return new WaitForSeconds(Part6Anim.GetCurrentAnimatorStateInfo(0).length + Part6Anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Part6Arrows.SetActive(true);
        }
    public void ButtonClicked(string command)
        {
            Debug.Log(command);
            switch (command)
            {
                case "Next":
                    part++;
                    break;
                case "Back":
                    part--;
                    break;
                case "Reset":
                    part = 1;
                    break;
            }
            SetPart(part);
        }
    }

}