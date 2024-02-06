using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToRunState : PlayerBaseState {
    public PlayerToRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {}

    public override void EnterState() {
        Debug.Log("Player is Running " + Time.time);
        _ctx._animationHandler.PlayAnimation("ToRun");
    }

    public override void CheckSwitchStates() {
        HandleMovement();
        _ctx._animationHandler.IfCurrentAnimationEndThen(LoopRun);
        if(_ctx._isAttackPressed) {
            SwitchState(_factory.LightAttack1());
        }else if(!_ctx._movementInputDetected) {
            SwitchState(_factory.Idle());
        } else if(!_ctx._isShiftPressed){
            SwitchState(_factory.Walk());
        }
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void ExitState() {}

    public override void InitializeSubState() {}

    private void HandleMovement(){
       _ctx._playerStats.currentSpeed += _ctx._playerStats.runAcceleration * Time.deltaTime;
       if(_ctx._playerStats.currentSpeed >= _ctx._playerStats.runSpeed){
        _ctx._playerStats.currentSpeed = _ctx._playerStats.runSpeed;
       }
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.currentSpeed, _ctx._rb.velocity.y); 
    }

    void LoopRun(){
        SwitchState(_factory.Run());
    }
}
