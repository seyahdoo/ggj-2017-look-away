using UnityEngine;
using System.Collections;
using Tobii.EyeTracking;
using System;

public class GuardAI : MonoBehaviour {

    public GazeAware gaze;
    NavMeshAgent nav;
    Animator anim;


    public Transform goal;
    public Transform look;
    public Transform monster;

    public float Temp = 0;
    public bool Terrified = false;
    public bool Jumping = false;
    public bool Dead = false;


    public float LookTerrifyDistance = 2;
    public float MonsterJumpDistance = 5;
    public float WallJumpDistance = 5;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //print("hey");
        if (Dead) return;

        

        anim.SetFloat("speed", nav.velocity.magnitude);

        if (gaze.HasGazeFocus)
        {
            //burning
            Temp += Time.deltaTime;
        }

        if ((Temp > 1) && !Terrified)
        {
            Achievements.Instance.UnlockAchievement("Terrorize!");
            //if looking to me, terrified, look to me
            Terrified = true;
            anim.SetBool("terrified", true);
            Yeller.Instance.Yell();
            GameManager.Instance.OnGuardFirstTouch();
        }

        //if terrified->
        if (Terrified)
        {
            if (gaze.HasGazeFocus)
            {
                //if looking directly me OR monster very near OR wall very near -> jump away, terrified
                Quaternion rot = Quaternion.Euler(0, 90, 0);
                Vector3 rotted = rot * (transform.position - monster.position);

                //Quaternion rot = Quaternion.Euler(0, 90, 0);
                //Vector3 nnowwe = rot * (look.position - monster.position);
                //Debug.DrawRay(transform.position, nnowwe);
                nav.destination = (transform.position + rotted); //90* from look vector
                nav.Resume();
            }
            //else if (Vector3.Distance(monster.position,transform.position) < MonsterJumpDistance)
            //{
            //    //OR monster very near
            //    JumpAway(transform.position + transform.position - monster.position); //away monster
            //}else if (Vector3.Distance(NearestWallPos(),transform.position) < WallJumpDistance)
            //{
            //    JumpAway(NearestWallPos()); //Away wall
            //}

            else if (Vector3.Distance(look.position,transform.position) < LookTerrifyDistance)
            {
                //if looking near me run!
                nav.destination = (transform.position + (transform.position - look.position) + (transform.position - monster.position));
                nav.Resume();
            }
            else
            {
                //if looking away play terrified
                //just be terrified,and maybe walk to corner
                nav.Stop();
                
            }

        }



        //if looking to me too much Burn()
        if ((Temp > 5) && !Dead )
        {
            Achievements.Instance.UnlockAchievement("Kill the Innocent...");
            //fire Death
            anim.SetTrigger("dead");
            Dead = true;
            nav.Stop();
            Yeller.Instance.Yell();
            GameManager.Instance.OnGuardDie();
        }

        
	}

    private Vector3 NearestWallPos()
    {
        //throw new NotImplementedException();
        return new Vector3(1, 1, 1);
    }

    //private void JumpAway(Vector3 from)
    //{
    //    print("Jumping away!");
    //    //throw new NotImplementedException();
    //}
}
