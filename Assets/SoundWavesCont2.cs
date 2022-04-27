using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWavesCont2 : MonoBehaviour
{
    public SoundButton PauseResume;
    public SoundButton Restart;
    public SoundButton Zoom;
    public Sprite Silver;
    public Sprite Steel;
    public Sprite Water;
    public GameObject MaterialLarge;
    public GameObject HammerOverlay;
    public GameObject Hammer;
    public List<GameObject> Waves;
    public float WaveTimer = 0f;
    public float WaveSpeed;
    float Timer;
    float AnimTimer;
    public GameObject spawnPos;
    public GameObject Wave;
    int WavesCreated;
    int WavesToCreate;
    string Material;

    bool running = false;
    private void FixedUpdate()
    {
        if(running)
        {
            if (WavesCreated != WavesToCreate)
            {
                if (WaveTimer <= 0f)
                {
                    GameObject obj = Instantiate(Wave, spawnPos.transform.position, new Quaternion(), this.transform);
                    obj.SetActive(true);
                    Waves.Add(obj);
                    WaveTimer += 1f;
                    WavesCreated++;
                }
                else
                {
                    WaveTimer -= Time.fixedDeltaTime;
                }
            }
            foreach (GameObject obj in Waves)
            {
                obj.transform.position += new Vector3(WaveSpeed, 0, 0);
            }
            Timer += Time.fixedDeltaTime;
            if(Timer >= AnimTimer)
            {
                Timer = 0;
                WaveTimer = 0;
                WavesCreated = 0;
                running = false;
                PauseResume.DisableButton();
                Restart.DisableButton();
                Zoom.DisableButton();
                HammerOverlay.SetActive(false);
                Hammer.GetComponent<BoxCollider2D>().enabled = true;
                foreach (GameObject obj in Waves)
                {
                    Destroy(obj);
                }
            }
        }
    }
    public void HammerClicked()
    {
        Waves = new List<GameObject>();
        StartCoroutine(HammerAnim());
    }
    IEnumerator HammerAnim()
    {
        Hammer.GetComponent<BoxCollider2D>().enabled = false;
        Hammer.GetComponent<Animator>().enabled = true;
        Animator anim = Hammer.GetComponent<Animator>();
        anim.Play("New Animation", -1, 0f);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        HammerOverlay.SetActive(true);
        running = true;
        PauseResume.gameObject.SetActive(true);
        PauseResume.EnableButton();
        Restart.gameObject.SetActive(true);
        Restart.EnableButton();
        Zoom.gameObject.SetActive(true);
        Zoom.EnableButton();
        anim.enabled = false;
    }
    public void ButtonClicked(string Mode)
    {
        if(Mode == "Pause")
        {
            running = false;
            PauseResume.Mode = "Resume";
            PauseResume.Rename("Tęsti");
        }
        if (Mode == "Resume")
        {
            running = true;
            PauseResume.Mode = "Pause";
            PauseResume.Rename("Pauzė");
        }
        if (Mode == "Restart")
        {
            MaterialClicked(Material);
        }
    }
    public void MaterialClicked(string material)
    {
        Material = material;
        Timer = 0;
        WaveTimer = 0;
        WavesCreated = 0;
        running = false;
        HammerOverlay.SetActive(false);
        Hammer.GetComponent<BoxCollider2D>().enabled = true;
        foreach (GameObject obj in Waves)
        {
            Destroy(obj);
        }
        PauseResume.gameObject.SetActive(false);
        Restart.gameObject.SetActive(false);
        Zoom.gameObject.SetActive(false);
        switch (Material)
        {
            case "Silver":
                MaterialLarge.SetActive(true);
                MaterialLarge.GetComponent<SpriteRenderer>().sprite = Silver;
                AnimTimer = 8.23f;
                WavesToCreate = 5;
                WaveSpeed = 0.084f;
                break;
            case "Steel":
                MaterialLarge.SetActive(true);
                MaterialLarge.GetComponent<SpriteRenderer>().sprite = Steel;
                AnimTimer = 4.20f;
                WavesToCreate = 3;
                WaveSpeed = 0.16f;
                break;
            case "Water":
                MaterialLarge.SetActive(true);
                MaterialLarge.GetComponent<SpriteRenderer>().sprite = Water;
                AnimTimer = 16.70f;
                WavesToCreate = 10;
                WaveSpeed = 0.0458f;
                break;
        }
    }
   
}
