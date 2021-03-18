using UnityEngine;
using System.Collections;

public class GuardSound : Singleton<GuardSound> {

    public AudioSource aus;

	public static AudioSource Source()
    {
        
        return GuardSound.Instance.aus;
    }

}
