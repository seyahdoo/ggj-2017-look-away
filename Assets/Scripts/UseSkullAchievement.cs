using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class UseSkullAchievement : MonoBehaviour {

    public GazeAware gaze;
	
	// Update is called once per frame
	void Update () {
        if (gaze.HasGazeFocus)
        {
            if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.E))
            {
                Achievements.Instance.UnlockAchievement("Use the skull.");
                gameObject.SetActive(false);
            }
        }
	}
}
