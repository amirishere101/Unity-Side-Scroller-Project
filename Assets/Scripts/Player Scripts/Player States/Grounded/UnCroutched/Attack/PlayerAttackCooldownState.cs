using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCooldownState : PlayerBaseState{
    //public bool allowNextAttack;
    public PlayerAttackCooldownState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

   public override void EnterState(){
        //_ctx._animationHandler.SetBool("Combo", false);
    }

    public override void CheckSwitchStates() {
        // if(_ctx._animationHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
        //     SwitchState(_factory.Idle());
        // }
    }

    public override void ExitState(){
        //_ctx._canFlipSprite = true;
    }

    public override void InitializeSubState(){
    }

    public override void UpdateState(){
        //CheckSwitchStates();
    }
}
