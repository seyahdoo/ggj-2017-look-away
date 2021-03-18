using UnityEngine;
using System.Collections;

public class TalkGuardAchievement : MonoBehaviour {

    public Transform playert;
    
	
	// Update is called once per frame
	void Update () {
	    
        if((Vector3.Distance(playert.position,transform.position)<2) && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.E)))
        {
            Achievements.Instance.UnlockAchievement("Try to communicate...");
            gameObject.SetActive(false);
        }

	}

}
