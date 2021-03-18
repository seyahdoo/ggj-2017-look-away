using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {


    public AudioSource musicSource;

    public AudioClip sadStory;

    public Transform SoulPlace;
    public Transform Ragdoll;
    public Transform Chest;
    public Transform Ascender;
    public SmoothFollow sfAscender;

    public float AscendSpeed = 0.03f;
    public float AscendForce = 20;

    public void OnGuardFirstTouch()
    {

        //mute music
        musicSource.mute = true;




    }


    public void OnGuardDie()
    {

        //sad story bro
        musicSource.clip = sadStory;
        musicSource.mute = false;
        musicSource.Play();

        StartCoroutine(SoulThingie());

    }


    IEnumerator SoulThingie()
    {
        yield return new WaitForSeconds(2f);

        //warp ragdoll
        Ragdoll.position = SoulPlace.position;
        Ragdoll.rotation = SoulPlace.rotation;

        yield return new WaitForSeconds(1f);

        //sfAscender.TargetTransform.position = sfAscender.MyTransform.position;
        //sfAscender.TargetTransform.rotation = sfAscender.MyTransform.rotation;

        Ragdoll.gameObject.SetActive(true);

        //fix
        //Chest.GetComponent<Rigidbody>().AddForce(transform.up * AscendForce, ForceMode.Force);

        //sfAscender.Following = true;

        while (true)
        {

            //sfAscender.TargetTransform.Translate(0, AscendSpeed, 0);
            Chest.GetComponent<Rigidbody>().AddForce(transform.up * AscendForce,ForceMode.VelocityChange);

            yield return new WaitForEndOfFrame();
        }


    }


	
}
