using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace sviesosspalvos
{
    public class ColorsController : MonoBehaviour
    {
        public TextMeshPro TopText;
        public GameObject ColorAndCircleObjects;
        bool Red, Orange, Yellow, Green, Cyan, Blue, Purple = false;
        bool Wire1, Wire2, Wire3 = false;
        bool Wheel = false;
        public Arrows arrows;
        public SwitchController switchController;
        string DefaultWires = "Sujunkite elektrinę grandinę";
        string Wires1 = "Prie varikliuko prijunkite jungiklį";
        string Wires2 = "Prie elektros srovės šaltinio prijunkite jungiklį";
        string Wires3 = "Prie elektros srovės šaltinio prijunkite varikliuką";
        string DefaultColors = "Iš septynių spektro spalvų sudarykite apskritimą";
        string Colors2 = "Užmaukite spalvų skritulį ant varikliuko ašies";
        string Switch = "Įjunkite jungiklį.";
        public GameObject ColoredCircle;
        public GameObject MountedCircle;
        public bool Colors()
        {
            if (Red && Orange && Yellow && Green && Cyan && Blue && Purple)
            {
                if (!Wheel)
                {
                    ColoredCircle.SetActive(true);
                    ColoredCircle.GetComponent<ColoredCircle>().Activate();
                    ColorAndCircleObjects.SetActive(false);
                    
                }
                return true;
            }
                
            else return false;
        }
        public bool Wires()
        {
            if (Wire1 && Wire2 && Wire3)
                return true;
            else return false;
        }
        public void SetColorMode(string name)
        {
            arrows.ShowArrow(name);
            TopText.text = DefaultColors;
            
            if(Colors())
            {
                TopText.text = Colors2;
                if (Wheel)
                    SetWireMode();
            }
            
        }
        public void SetWireMode(string name)
        {
            arrows.ShowArrow(name);
            if (name == "Wire 1")
            {
                TopText.text = DefaultWires + " " + Wires1;
            }
            if (name == "Wire 2")
            {
                TopText.text = DefaultWires + " " + Wires2;
            }
            if (name == "Wire 3")
            {
                TopText.text = DefaultWires + " " + Wires3;
            }
            if(Wires())
            {
                SetColorMode();
            }
        }
        public void SetWireMode()
        {
            if (!Wires())
            {
                arrows.ShowArrow("Wires");
                TopText.text = DefaultWires;
            }
            else
            {
                if (!Colors() || !Wheel)
                {
                    SetColorMode();
                }
                else
                {
                    switchController.ready = true;
                    TopText.text = Switch;
                    arrows.ShowArrow("Switch");
                }
            }
        }
        public void SetColorMode()
        {
            if (!Colors())
            {
                TopText.text = DefaultColors;
                if (!Yellow)
                    arrows.ShowArrow("Yellow");
                if (!Red)
                    arrows.ShowArrow("Red");
                if (!Green)
                    arrows.ShowArrow("Green");
                if (!Orange)
                    arrows.ShowArrow("Orange");
                if (!Blue)
                    arrows.ShowArrow("Blue");
                if (!Purple)
                    arrows.ShowArrow("Purple");
                if (!Cyan)
                    arrows.ShowArrow("Cyan");
            }
            else
            {
                if (!Wheel)
                {
                    arrows.ShowArrow("Circle");
                    TopText.text = Colors2;
                }
                else
                {
                    if (!Wires())
                    {
                        SetWireMode();
                    }
                    else
                    {
                        switchController.ready = true;
                        TopText.text = Switch;
                        arrows.ShowArrow("Switch");
                    }
                }
            }

        }
        public void ColorSet(string name)
        {
            switch (name)
            {
                case "Red":
                    Red = true;
                    break;
                case "Orange":
                    Orange = true;
                    break;
                case "Yellow":
                    Yellow = true;
                    break;
                case "Green":
                    Green = true;
                    break;
                case "Cyan":
                    Cyan = true;
                    break;
                case "Blue":
                    Blue = true;
                    break;
                case "Purple":
                    Purple = true;
                    break;
            }
        }
        public void CircleSet()
        {
            Wheel = true;
            ColoredCircle.SetActive(false);
            MountedCircle.SetActive(true);
            MountedCircle.GetComponent<MountedCircle>().Activate();
        }
        public void WireSet(string name)
        {
            switch (name)
            {
                case "Wire 1":
                    Wire1 = true;
                    break;
                case "Wire 2":
                    Wire2 = true;
                    break;
                case "Wire 3":
                    Wire3 = true;
                    break;
            }
        }
    }
}
