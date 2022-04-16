using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixturesThreePanelsController : MonoBehaviour
{
    public MixturesButton[] Buttons;
    public MixturesGreyButton GreyButton;
    public GameObject Timer;
    public GameObject Months;
    public GameObject Panels;
    public MixturesButton ActiveButton;
    public void SelectButton(MixturesButton selected)
    {
        Panels.SetActive(true);
        if(ActiveButton != null)
        {
            ActiveButton.Unselect();
            if(ActiveButton.Animation.running)
            {
                ActiveButton.Animation.StopAnimation();
            }
            
        }
        selected.Select();
        GreyButton.gameObject.SetActive(true);
        GreyButton.ReloadGreyButton();
        if (selected.timer)
        {
            Timer.SetActive(true);
            Months.SetActive(false);
        }
        else
        {
            Months.SetActive(true);
            Timer.SetActive(false);
        }
        ActiveButton = selected;
    }
}
