using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreakRunState : PlayerBaseState {
    public PlayerBreakRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {}

    public override void EnterState() {
        _ctx._animationHandler.PlayAnimation("BreakRun");
    }

    public override void CheckSwitchStates() {
        HandleMovement();
        if(_ctx._animationHandler.animator.GetCurrentAnimatorStateInfo(0).length >= 0.6f){
            if(_ctx._movementInputDetected){
                _ctx._animationHandler.IfCurrentAnimationEndThen(Walk);
            } else {
                _ctx._animationHandler.IfCurrentAnimationEndThen(Idle);
            }
        } else {
            if(_ctx._isAttackPressed) {
                SwitchState(_factory.LightAttack1());
            } if (_ctx._isShiftPressed && _ctx._movementInputDetected){
                SwitchState(_factory.Run());
            }
        }
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void ExitState() {}

    public override void InitializeSubState() {}

    private void HandleMovement(){
       _ctx._playerStats.currentSpeed -= _ctx._playerStats.walkAcceleration * Time.deltaTime;
        _ctx._playerStats.currentSpeed = Mathf.Clamp(_ctx._playerStats.currentSpeed, 0, _ctx._playerStats.walkSpeed);
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.currentSpeed, _ctx._rb.velocity.y); 
    }

    void Idle(){
        SwitchState(_factory.Idle());
    }

    void Walk(){
        SwitchState(_factory.Idle());
    }
}
