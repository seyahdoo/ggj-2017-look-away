using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class GazeDebugger : MonoBehaviour {

    public LayerMask lmask;

	// Update is called once per frame
	void Update () {

        GazePoint gp = EyeTracking.GetGazePoint();

        if (!gp.IsWithinScreenBounds) return;
        //print(gp.Screen.x + "+" + gp.Screen.y);

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(gp.Screen.x, gp.Screen.y, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,float.MaxValue,lmask))
        {
            //print("I'm looking at " + hit.transform.name);
            transform.position = hit.point;
        }
            //print("I'm looking at nothing!");


    }
}
