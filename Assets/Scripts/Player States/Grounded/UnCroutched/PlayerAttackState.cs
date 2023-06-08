using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState{
    public bool allowNextAttack;
    public PlayerAttackState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        Debug.Log("Attack!" + Time.time);
        _ctx._canFlipSprite = false;
        allowNextAttack = false;
        _ctx._isAttackPressed = false;
        _ctx._animationHandler.PlayAnimation("Knife Attack 1");
        _ctx._knife.EnableKnifeHitbox();
    }

    public override void CheckSwitchStates() {
        if(_ctx._animationHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("Put Knife Away 1") 
        || _ctx._animationHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("Put Knife Away 2") 
        || _ctx._animationHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("Put Knife Away 3")){
            SwitchState(_factory.KnifeAttackCooldown());
        }
    }

    public override void ExitState(){
        _ctx._knife.DisableKnifeHitBox();
    }

    public override void InitializeSubState(){
    }

    public override void UpdateState(){
        if(_ctx._isAttackPressed){
            _ctx._isAttackPressed = false;
            _ctx._animationHandler.SetBool("Combo", true);
        }
        CheckSwitchStates();
    }
}
