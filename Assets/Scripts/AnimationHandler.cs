using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    private string _currentAnimation;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName){
        animator.Play(animationName);
        _currentAnimation = animationName;
    }

    public void SetBool(string boolName, bool boolean){
        animator.SetBool(boolName, boolean);
    }

    public void IfCurrentAnimationEndThen(Action onAnimationComplete){
		if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1){
			onAnimationComplete.Invoke();
		}
	}
}
