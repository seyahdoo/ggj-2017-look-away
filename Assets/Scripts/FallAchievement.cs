using UnityEngine;
using System.Collections;

public class FallAchievement : MonoBehaviour {

    public GameObject gameOver;

    void OnTriggerEnter(Collider other)
    {

        //Achievement Unlocked!
        if (other.tag == "Player")
        {
            Achievements.Instance.UnlockAchievement("Manage to fall from known universe...");
            StartCoroutine(Gameover());
        }

    }

    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3f);

        gameOver.SetActive(true);

        yield return new WaitForSeconds(3f);

        Debug.Log("Done!");

        Application.Quit();

    }

}
