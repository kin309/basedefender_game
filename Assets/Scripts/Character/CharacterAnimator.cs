using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    string currentState;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationState.Char_Punch.ToString()) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) 
        {
            ChangeAnimationState(AnimationState.Char_Idle.ToString());
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    public string GetCurrentAnimation()
    {
        return currentState;
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

}

public enum AnimationState
{
    Char_Idle,
    Char_Walk,
    Char_Punch,
}