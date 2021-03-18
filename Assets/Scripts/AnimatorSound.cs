using UnityEngine;
using System.Collections;

public class AnimatorSound : StateMachineBehaviour {
    
    public AudioClip[] clips;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (clips.Length>0)
        {
            GuardSound.Source().mute = false;
            GuardSound.Source().PlayOneShot(clips[Random.Range(0, clips.Length)]);
        } else
        {
            GuardSound.Source().mute = true;
        }
            
	}
    
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (!GuardSound.Source().isPlaying)
        {
            GuardSound.Source().PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
    
}
