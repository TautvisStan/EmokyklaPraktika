using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace rega
{
    public class SeeingAnimButton : MonoBehaviour
    {
        public TextMeshPro ButtonText;
        public Sprite Enabled;
        public Sprite Disabled;
        public Sprite Hover;
        private SpriteRenderer Button;
        public bool buttonEnabled = true;
        public Animator Anim;
        private void Start()
        {
            Button = GetComponent<SpriteRenderer>();
        }
        private void OnMouseEnter()
        {
            if(buttonEnabled)
            {
                Button.sprite = Hover;
            }
        }
        private void OnMouseExit()
        {
            if (buttonEnabled)
            {
                Button.sprite = Enabled;
            }
        }
        private void OnMouseDown()
        {
            if(buttonEnabled)
            {
                StartCoroutine(Animation());
            }
        }
        IEnumerator Animation()
        {
            
            buttonEnabled = false;
            Button.sprite = Disabled;
            Anim.enabled = true;
            Anim.Play("New Animation", -1, 0);
            yield return new WaitForSeconds(Anim.GetCurrentAnimatorStateInfo(0).length + Anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Anim.enabled = false;
            ButtonText.text = "Kartoti";
            buttonEnabled = true;
            Button.sprite = Enabled;

        }
    }
}