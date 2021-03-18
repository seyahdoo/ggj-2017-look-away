using UnityEngine;
using System.Collections;

public class Yeller : Singleton<Yeller> {

    public AudioClip[] clips;
    public AudioSource aus;
    

    public void Yell()
    {

        GuardSound.Source().PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }

    
}
