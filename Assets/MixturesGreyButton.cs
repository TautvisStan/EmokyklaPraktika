using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MixturesGreyButton : MonoBehaviour
{
    public GameObject Aura;
    public TextMeshPro TimerText;
    public TextMeshPro MonthsText;
    public MixturesThreePanelsController main;
    bool running = false;
    public void ReloadGreyButton()
    {
        Aura.SetActive(true);
        TimerText.text = "00:00";
        MonthsText.text = "00";
        running = false;
    }
    private void OnMouseDown()
    {
        if(!running)
        {
            Aura.SetActive(false);
            running = true;
            main.ActiveButton.Animation.StartAnimation();
        }
    }
}
