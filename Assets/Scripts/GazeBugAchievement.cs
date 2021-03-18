using UnityEngine;
using System.Collections;

public class GazeBugAchievement : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        //Achievement Unlocked!
        if (other.tag == "Player")
        {
            Achievements.Instance.UnlockAchievement("Find the 'gaze' bug collider...");
            gameObject.SetActive(false);
        }

    }
}
