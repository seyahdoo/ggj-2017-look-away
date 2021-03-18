using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;

public class SimpleSphere : MonoBehaviour {

    public GazeAware gaze;
    public Material mat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (gaze.HasGazeFocus)
        {
            print("Look");
            mat.color = Color.red;
        }
        else
        {
            mat.color = Color.blue;
        }
        
	}
}
