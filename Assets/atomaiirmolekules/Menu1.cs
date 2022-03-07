using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace atomaiirmolekules
{
    public class Menu1 : MonoBehaviour
    {
        // Start is called before the first frame update
        public GlassVideo glassPlayer;
        public Glass[] glasses;
        public void DisplayGlass(int num)
        {
            glassPlayer.displayGlass(num);
            foreach( Glass glass in glasses)
            {
                glass.enabled = false;
            }
        }
        public void EnableGlasses()
        {
            foreach (Glass glass in glasses)
            {
                glass.enabled = true;
            }
        }
    }
}