using UnityEngine;
using System.Collections;

public class LevelParkourAchievement : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        //Achievement Unlocked!
        if (other.tag == "Player")
        {
            Achievements.Instance.UnlockAchievement("Parkour");
            gameObject.SetActive(false);
        }

    }


}
