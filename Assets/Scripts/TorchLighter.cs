using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class TorchLighter : MonoBehaviour {

    public GazeAware gaze;
    public GameObject lightobj;
    public TorchAudio tau;


    float warm = 0;

    void FixedUpdate()
    {

        if (gaze.HasGazeFocus)
        {
            warm++;
        }else
        {
            warm--;
        }

        if (warm < 0) warm = 0;

        if(warm > 100)
        {

            tau.MakeSound();

            Achievements.Instance.UnlockAchievement("Light the torch!");
            lightobj.SetActive(true);
            this.gameObject.SetActive(false);

        }


    }


}
