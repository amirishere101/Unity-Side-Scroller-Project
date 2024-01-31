using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToWalkState : PlayerBaseState {

    public PlayerToWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory) {}

    public override void EnterState(){
        Debug.Log("Player is Walking " + Time.time);
        _ctx._animationHandler.PlayAnimation("ToWalk");
    }

    public override void UpdateState(){
        HandleMovement();
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        _ctx._animationHandler.IfCurrentAnimationEndThen(LoopWalk);
        if(_ctx._isAttackPressed){
            SwitchState(_factory.KnifeAttack1());
        }else if(!_ctx._movementInputDetected) {
            SwitchState(_factory.Idle());
        } else if(_ctx._isShiftPressed){
            SwitchState(_factory.ToRun());
        }
    }

    public override void ExitState(){}

    private void HandleMovement(){
        _ctx._playerStats.currentSpeed += _ctx._playerStats.walkAcceleration * Time.deltaTime;
       if(_ctx._playerStats.currentSpeed >= _ctx._playerStats.walkSpeed){
        _ctx._playerStats.currentSpeed = _ctx._playerStats.walkSpeed;
       }
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.currentSpeed, _ctx._rb.velocity.y); 
    }

    void LoopWalk(){
        SwitchState(_factory.Walk());
    }

    public override void InitializeSubState(){}

}
