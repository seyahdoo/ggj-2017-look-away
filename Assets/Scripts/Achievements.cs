using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Achievements : Singleton<Achievements> {


    public List<string> unlocked = new List<string>();
    int lightCount = 0;
    int parkourCount = 0;

    public Text text;

	public void UnlockAchievement(string achievement)
    {
        if(achievement == "Light the torch!")
        {
            lightCount++;
            if(lightCount >= 8)
            {
                UnlockAchievement("Torchmaster -> (Light them ALL!)");
                return;
            }
        }

        if(achievement == "Parkour")
        {
            parkourCount++;
            if(parkourCount >= 16)
            {
                UnlockAchievement("Parkourmaster -> (DO them ALL!)");
            }
            else
            {
                UnlockAchievement("Parkour "+parkourCount+"!");
            }
            return;

        }

        if (!unlocked.Contains(achievement))
        {
            unlocked.Add(achievement);
            StartCoroutine(Unlock(achievement));
        }
        
    }

    IEnumerator Unlock(string achievement)
    {
        text.text = "ACHIEVEMENT UNLOCKED: \n" + achievement;

        Color c = text.material.color;
        c.a = 1f;
        text.material.color = c;

        yield return new WaitForSeconds(2f);

        while (c.a > 0)
        {
            c.a -= 0.01f;

            text.material.color = c;
            yield return new WaitForFixedUpdate();
        }
        


        yield return null;
    }



}
