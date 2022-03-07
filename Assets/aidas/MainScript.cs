using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Person person;
    public Dog dog;
    public Sounds sounds;

    public void Play()
    {
        
        StartCoroutine(movie());
    }

    IEnumerator movie()
    {
        
        person.PlayAnimation();
        yield return new WaitForSeconds((float)0.7);
        sounds.PlayAnimation(1);
        yield return new WaitForSeconds(1);
        sounds.PlayAnimation(2);
        yield return new WaitForSeconds(3);
        dog.PlayAnimation();
        yield return new WaitForSeconds((float)0.2);
        sounds.PlayAnimation(3);
        yield return new WaitForSeconds((float)1);
        sounds.PlayAnimation(4);
    }
}
