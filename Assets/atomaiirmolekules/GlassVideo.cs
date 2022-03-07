using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

namespace atomaiirmolekules
{
    public class GlassVideo : MonoBehaviour
    {
        public Menu1 Menu;
        public VideoClip[] clips;
        public string[] texts;
        public VideoPlayer player;
        public GameObject text;
        public GameObject window;
        // Start is called before the first frame update
        public void displayGlass(int num)
        {
            window.SetActive(true);
            player.clip = clips[num - 1];
            text.GetComponent<TextMeshPro>().text = texts[num - 1];
            player.enabled = true;
        }
        public void disableDisplay()
        {
            player.enabled = false;
            window.SetActive(false);
            Menu.EnableGlasses();
        }
    }
}