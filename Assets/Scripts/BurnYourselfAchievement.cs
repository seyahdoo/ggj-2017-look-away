using UnityEngine;
using System.Collections;

public class BurnYourselfAchievement : MonoBehaviour {

    public Transform flamet;

    public float Distance = 1;

    void Update()
    {

        if (Vector3.Distance(flamet.position, transform.position) < Distance)
        {
            Achievements.Instance.UnlockAchievement("Manage to burn yourself...");
            gameObject.SetActive(false);
        }

    }
    


}
