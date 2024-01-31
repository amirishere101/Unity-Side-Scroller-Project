using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState {

    public PlayerIdleState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){}

    public override void EnterState(){
        Debug.Log("Player Is Idle " + Time.time);
        _ctx._rb.velocity = Vector2.zero;
        _ctx._animationHandler.PlayAnimation("Idle");
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        if(_ctx._isAttackPressed){
            SwitchState(_factory.KnifeAttack1());
        }else if(_ctx._movementInputDetected){
            SwitchState(_factory.ToWalk());
        }
    }

    public override void ExitState(){}

    public override void InitializeSubState(){}

}
