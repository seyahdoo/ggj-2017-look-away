using UnityEngine;
using System.Collections;

public class PillarAchievement : MonoBehaviour {



    void OnTriggerEnter(Collider other)
    {
        
        //Achievement Unlocked!
        if(other.tag == "Player")
        {
            Achievements.Instance.UnlockAchievement("Realize the Pillar BUG!");

        }
        
    }





}
