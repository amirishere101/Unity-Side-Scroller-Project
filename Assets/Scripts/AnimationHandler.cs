using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public IEnumerator EnqueueNextAnimation(string animationName){
        while(animator.GetCurrentAnimatorStateInfo(0).IsName(currentAnimation)){
            yield return null;
        }
        PlayAnimation(animationName);
    }

    public void PlayAnimation(string animationName){
        animator.Play(animationName);
        currentAnimation = animationName;
    }

    public void SetBool(string boolName, bool boolean){
        animator.SetBool(boolName, boolean);
    }
}
