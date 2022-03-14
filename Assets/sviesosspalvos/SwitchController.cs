using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace sviesosspalvos
{
    public class SwitchController : MonoBehaviour
    {
        public bool ready = false;
        bool on = false;
        public MountedCircle circle;
        public GameObject TurnedOn;
        public GameObject TurnedOff;
        string SwitchTurnedOn = "Jungiklis įjungtas. Stebėkite šviesos spalvų sudėtį. Baigę stebėjimą užpildykite atsiskaitymo lapą.";
        string SwitchTurnedOff = "Jungiklis išjungtas. Įjunkite jungiklį.";
        public TextMeshPro TopText;
        public Arrows arrows;

        void OnMouseDown()
        {
            if (ready)
            {
                if (!on)
                {
                    on = true;
                    circle.Spinning();
                    TopText.text = SwitchTurnedOn;
                    arrows.RemoveArrows();
                    TurnedOff.SetActive(false);
                    TurnedOn.SetActive(true);
                }
                else
                {
                    on = false;
                    circle.Slowing();
                    TopText.text = SwitchTurnedOff;
                    arrows.ShowArrow("Switch");
                    TurnedOff.SetActive(true);
                    TurnedOn.SetActive(false);
                }

            }
        }
    }
}