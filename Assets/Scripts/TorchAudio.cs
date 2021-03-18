using UnityEngine;
using System.Collections;

public class TorchAudio : MonoBehaviour {

    public AudioClip start;
    public AudioClip loop;
    public AudioSource aus;

	public void MakeSound()
    {
        aus.Stop();
        aus.PlayOneShot(start);
        StartCoroutine(Loopit());
    }

    IEnumerator Loopit()
    {
        while (aus.isPlaying)
        {
            yield return new WaitForEndOfFrame();
        }

        aus.Stop();
        aus.PlayOneShot(loop);
        aus.loop = true;

        
    }
	
}
