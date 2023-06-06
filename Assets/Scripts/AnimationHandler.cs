using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animationName){
        animator.Play(animationName);
    }

    public void SetBool(string boolName, bool boolean){
        animator.SetBool(boolName, boolean);
    }
}
