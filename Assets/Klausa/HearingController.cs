using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HearingController : MonoBehaviour
{
    public HearingSoundwave[] waves;
    int stage = 0;
    public TextMeshPro PanelText;
    public string Text1;
    public string Text2;
    public string Text3;
    public string Text4;
    public Sprite EnabledBackground;
    public Sprite DisabledBackground;
    public Sprite HoverBackground;
    public TextMeshPro ButtonText;
    public string BText1;
    public string BText2;
    public string BText3;
    public SpriteRenderer ButtonImage;
    bool buttonEnabled = true;
    public GameObject Animation1;
    public GameObject Animation2;
    public GameObject Animation3;
    public Animation FadeIn;
    public Animation Reposition;
    public Animator BrainAnimation;
    public GameObject BackState;
    public GameObject CurrentState;
    private void Start()
    {
        CurrentState = GetComponentInParent<HearingState>().gameObject;
        BackState = GetComponentInParent<HearingMainState>().StateToInstantiate;
    }
    private void OnMouseDown()
    {
        if (buttonEnabled)
        {
            buttonEnabled = false;
            ButtonImage.sprite = DisabledBackground;
            if (stage == 0)
            {
                PanelText.text = Text1;
                foreach (HearingSoundwave wave in waves)
                {
                    wave.test();
                }
                StartCoroutine(PauseAllWaves());
            }
            if (stage == 1)
            {
                PanelText.text = Text2;
                Animation1.SetActive(true);
                foreach (HearingSoundwave wave in waves)
                {
                    wave.test();
                }
                StartCoroutine(PauseAllWaves());
            }
            if (stage == 2)
            {
                Animation1.SetActive(false);
                PanelText.text = Text3;
                Animation2.SetActive(true);
                foreach (HearingSoundwave wave in waves)
                {
                    wave.test();
                }
                StartCoroutine(PauseAllWaves());
            }
            if (stage == 3)
            {
                Animation2.SetActive(false);
                PanelText.text = Text4;
                Animation3.SetActive(true);
                FadeIn.Play();
                Reposition.Play();
                foreach (HearingSoundwave wave in waves)
                {
                    wave.test();
                }
                StartCoroutine(PauseAllWaves());
            }
            if (stage == 4)
            {
                //Instantiate(BackState, GetComponentInParent<HearingMainState>().gameObject,)
                GameObject Repeat = Instantiate(BackState, BackState.transform.position, new Quaternion(), GetComponentInParent<HearingMainState>().gameObject.transform);
                Repeat.SetActive(true);
                Destroy(CurrentState);
            }
        }
    }
    private void OnMouseEnter()
    {
        if(buttonEnabled)
        {
            ButtonImage.sprite = HoverBackground;
        }
    }
    private void OnMouseExit()
    {
        if (buttonEnabled)
        {
            ButtonImage.sprite = EnabledBackground;
        }
    }
    IEnumerator PauseAllWaves()
    {
        switch (stage)
        {
            case 0:
            case 1:
                yield return new WaitForSeconds(4);
                foreach (HearingSoundwave wave in waves)
                {
                    wave.PauseWave();
                }
                stage++;
                buttonEnabled = true;
                ButtonImage.sprite = EnabledBackground;
                ButtonText.text = BText2;
                break;
            case 2:
                yield return new WaitForSeconds(6);
                foreach (HearingSoundwave wave in waves)
                {
                    wave.PauseWave();
                }
                stage++;
                buttonEnabled = true;
                ButtonImage.sprite = EnabledBackground;
                ButtonText.text = BText2;
                break;
            case 3:
                yield return new WaitForSeconds(10);
                foreach (HearingSoundwave wave in waves)
                {
                    wave.PauseWave();
                }
                BrainAnimation.speed = 0;
                stage++;
                buttonEnabled = true;
                ButtonImage.sprite = EnabledBackground;
                ButtonText.text = BText3;
                break;
        }
    }
}
