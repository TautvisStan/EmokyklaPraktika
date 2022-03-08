using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace sviesosspalvos
{
    public class Arrows : MonoBehaviour
    {
        public GameObject Wires, Wire1, Wire2, Wire3, Cyan, Purple, Blue, Orange, Green, Red, Yellow, Switch, Engine, Circle;
        private Dictionary<string, GameObject> ArrowsDictionary = new Dictionary<string, GameObject>();
        private void Awake()
        {
            ArrowsDictionary.Add("Wires", Wires);
            ArrowsDictionary.Add("Wire 1", Wire1);
            ArrowsDictionary.Add("Wire 2", Wire2);
            ArrowsDictionary.Add("Wire 3", Wire3);
            ArrowsDictionary.Add("Cyan", Cyan);
            ArrowsDictionary.Add("Purple", Purple);
            ArrowsDictionary.Add("Blue", Blue);
            ArrowsDictionary.Add("Orange", Orange);
            ArrowsDictionary.Add("Green", Green);
            ArrowsDictionary.Add("Red", Red);
            ArrowsDictionary.Add("Yellow", Yellow);
            ArrowsDictionary.Add("Switch", Switch);
            ArrowsDictionary.Add("Engine", Engine);
            ArrowsDictionary.Add("Circle", Circle);
        }
        public void ShowArrow(string name)
        {
            foreach (var obj in ArrowsDictionary)
            {
                obj.Value.SetActive(false);
            }
            ArrowsDictionary[name].SetActive(true);
        }
        public void RemoveArrows()
        {
            foreach (var obj in ArrowsDictionary)
            {
                obj.Value.SetActive(false);
            }
        }
    }
}