using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace greicioapskaiciavimas
{
    public class SpeedMainController : MonoBehaviour
    {
        public GameObject Fox;
        public GameObject Giraffe;
        public GameObject Elephant;
        public GameObject FoxStart;
        public GameObject GiraffeStart;
        public GameObject ElephantStart;
        public GameObject FoxFinish;
        public GameObject GiraffeFinish;
        public GameObject ElephantFinish;
        public TextMeshPro DistText;
        public TextMeshPro FoxText;
        public TextMeshPro ElephantText;
        public TextMeshPro GiraffeText;
        public GameObject Flag;
        public GameObject Track1000;
        public GameObject Track2000;
        public GameObject Track3000;
        public float F1000 = 100;
        public float E1000 = 166;
        public float G1000 = 67;
        public float T1000 = 21;
        public float F2000 = 200;
        public float E2000 = 333;
        public float G2000 = 135;
        public float T2000 = 28;
        public float F3000 = 300;
        public float E3000 = 500;
        public float G3000 = 200;
        public float T3000 = 32;
        bool ElephantActive = false;
        bool GiraffeActive = false;
        bool FoxActive = false;
        int distance = 0;
        List<bool> bools = new List<bool>();
        public BoxCollider2D DistanceDropdown;
        public void SetDistance(int num)
        {
            bool ready = true;
            foreach (bool animal in bools)
            {
                if (animal == true)
                {
                    ready = false;
                }
            }
            if (ready)
            {
                Giraffe.transform.localPosition = GiraffeStart.transform.localPosition;
                Elephant.transform.localPosition = ElephantStart.transform.localPosition;
                Fox.transform.localPosition = FoxStart.transform.localPosition;
                Track1000.SetActive(false);
                Track2000.SetActive(false);
                Track3000.SetActive(false);
                if (num == 0)
                {
                    distance = 0;
                    Track1000.SetActive(true);
                    Fox.SetActive(false);
                    Elephant.SetActive(false);
                    Giraffe.SetActive(false);
                    DistText.text = "0";

                }
                else
                {
                    Fox.SetActive(true);
                    Elephant.SetActive(true);
                    Giraffe.SetActive(true);
                }
                if (num == 1)
                {
                    distance = 1000;
                    Track1000.SetActive(true);
                    DistText.text = "1000";

                }
                if (num == 2)
                {
                    distance = 2000;
                    Track2000.SetActive(true);
                    DistText.text = "2000";
                }
                if (num == 3)
                {
                    distance = 3000;
                    Track3000.SetActive(true);
                    DistText.text = "3000";
                }
            }

        }
        public void StartRace()
        {
            bool ready = true;
            foreach(bool animal in bools)
            {
                if (animal == true)
                {
                    ready = false;
                }
            }
            if (ready)
            {
                if (distance != 0)
                {
                    StartCoroutine(FlagAnimation());

                }

                if (distance == 1000)
                {
                    StartCoroutine(Animation(0, Elephant, ElephantFinish, T1000));
                    StartCoroutine(Animation(1, Fox, FoxFinish, F1000 / E1000 * T1000));
                    StartCoroutine(Animation(2, Giraffe, GiraffeFinish, G1000 / E1000 * T1000));
                    
                }
                if (distance == 2000)
                {
                    StartCoroutine(Animation(0, Elephant, ElephantFinish, T2000));
                    StartCoroutine(Animation(1, Fox, FoxFinish, F2000 / E2000 * T2000));
                    StartCoroutine(Animation(2, Giraffe, GiraffeFinish, G2000 / E2000 * T2000));
                    Track2000.GetComponent<Animator>().enabled = true;
                }
                if (distance == 3000)
                {
                    StartCoroutine(Animation(0, Elephant, ElephantFinish, T3000));
                    StartCoroutine(Animation(1, Fox, FoxFinish, F3000 / E3000 * T3000));
                    StartCoroutine(Animation(2, Giraffe, GiraffeFinish, G3000 / E3000 * T3000));
                    Track3000.GetComponent<Animator>().enabled = true;
                }
            }
        }
        private void Update()
        {
            float eleTime = 0;
            float girTime = 0;
            float foxTime = 0;
            switch (distance)
            {
                case 1000:
                    eleTime = E1000;
                    girTime = G1000;
                    foxTime = F1000;
                    break;
                case 2000:
                    eleTime = E2000;
                    girTime = G2000;
                    foxTime = F2000;
                    break;
                case 3000:
                    eleTime = E3000;
                    girTime = G3000;
                    foxTime = F3000;
                    break;
            }
            if (bools[0])
            {
                float xDist = ElephantFinish.transform.position.x - ElephantStart.transform.position.x;
                float dist = Elephant.transform.position.x - ElephantStart.transform.position.x;
                float percentage = dist / xDist;
                int timer = Mathf.RoundToInt(eleTime * percentage);
                string mins = (timer / 60).ToString();
                string secs = (timer % 60).ToString();
                if (secs.Length == 1)
                {
                    secs = "0" + secs;
                }
                ElephantText.text = string.Format("{0}:{1}", mins, secs);
                if (percentage == 1)
                {
                    bools[0] = false;
                    Elephant.GetComponent<Animator>().enabled = false;
                }
            }
            if (bools[1])
            {
                float xDist = FoxFinish.transform.position.x - FoxStart.transform.position.x;
                float dist = Fox.transform.position.x - FoxStart.transform.position.x;
                float percentage = dist / xDist;
                int timer = Mathf.RoundToInt(foxTime * percentage);
                string mins = (timer / 60).ToString();
                string secs = (timer % 60).ToString();
                if (secs.Length == 1)
                {
                    secs = "0" + secs;
                }
                FoxText.text = string.Format("{0}:{1}", mins, secs);
                if (percentage == 1)
                {
                    bools[1] = false;
                    Fox.GetComponent<Animator>().enabled = false;
                }
            }
            if (bools[2])
            {
                
                float xDist = GiraffeFinish.transform.position.x - GiraffeStart.transform.position.x;
                float dist = Giraffe.transform.position.x - GiraffeStart.transform.position.x;
                float percentage = dist / xDist;
                int timer = Mathf.RoundToInt(girTime * percentage);
                string mins = (timer / 60).ToString();
                string secs = (timer % 60).ToString();
                if (secs.Length == 1)
                {
                    secs = "0" + secs;
                }
                GiraffeText.text = string.Format("{0}:{1}", mins, secs);
                if (percentage == 1)
                {
                    bools[2] = false;
                    Giraffe.GetComponent<Animator>().enabled = false;
                }
            }
            bool racing = false;
            foreach (bool animal in bools)
            {
                if (animal == true)
                {
                    racing = true;
                }
            }
            DistanceDropdown.enabled = !racing;
            
        }
        void Start()
        {
            bools.Add(ElephantActive);
            bools.Add(FoxActive);
            bools.Add(GiraffeActive);


        }
        IEnumerator FlagAnimation()
        {
            Flag.SetActive(true);
            Animator anim = Flag.GetComponent<Animator>();
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            Flag.SetActive(false);
        }
        IEnumerator Animation(int elem, GameObject Animal, GameObject Finish, float RealTime)
        {
            Keyframe[] ksx = new Keyframe[2];
            ksx[0] = new Keyframe(0, Animal.transform.localPosition.x, 1, 1);
            ksx[1] = new Keyframe(RealTime, Finish.transform.localPosition.x, 1, 1);
            Keyframe[] ksy = new Keyframe[2];
            ksy[0] = new Keyframe(0, Animal.transform.localPosition.y, 0, 0);
            ksy[1] = new Keyframe(RealTime, Finish.transform.localPosition.y, 0, 0);
            AnimationCurve animx = new AnimationCurve(ksx);
            SetCurveLinear(animx);
            AnimationCurve animy = new AnimationCurve(ksy);
            AnimationClip clip = new AnimationClip();
            clip.SetCurve("", typeof(Transform), "localPosition.x", animx);
            clip.SetCurve("", typeof(Transform), "localPosition.y", animy);
            clip.legacy = true;

            Animation anim = Animal.GetComponent<Animation>();
            anim.AddClip(clip, "testClip");
            
            anim.Play("testClip");
            bools[elem] = true;
            Animal.GetComponent<Animator>().enabled = true;
            yield return WaitForAnim(anim["testClip"], 1);
        }

        IEnumerator WaitForAnim(AnimationState animclip, float spd)
        {
            var tempTime = animclip.length * (1 / spd);
            yield return new WaitForSeconds(tempTime);
        }
        public static void SetCurveLinear(AnimationCurve curve)
        {
            for (int i = 0; i < curve.keys.Length; ++i)
            {
                float intangent = 0;
                float outtangent = 0;
                bool intangent_set = false;
                bool outtangent_set = false;
                Vector2 point1;
                Vector2 point2;
                Vector2 deltapoint;
                Keyframe key = curve[i];

                if (i == 0)
                {
                    intangent = 0; intangent_set = true;
                }

                if (i == curve.keys.Length - 1)
                {
                    outtangent = 0; outtangent_set = true;
                }

                if (!intangent_set)
                {
                    point1.x = curve.keys[i - 1].time;
                    point1.y = curve.keys[i - 1].value;
                    point2.x = curve.keys[i].time;
                    point2.y = curve.keys[i].value;

                    deltapoint = point2 - point1;

                    intangent = deltapoint.y / deltapoint.x;
                }
                if (!outtangent_set)
                {
                    point1.x = curve.keys[i].time;
                    point1.y = curve.keys[i].value;
                    point2.x = curve.keys[i + 1].time;
                    point2.y = curve.keys[i + 1].value;

                    deltapoint = point2 - point1;

                    outtangent = deltapoint.y / deltapoint.x;
                }

                key.inTangent = intangent;
                key.outTangent = outtangent;
                curve.MoveKey(i, key);
            }
        }
    }
}