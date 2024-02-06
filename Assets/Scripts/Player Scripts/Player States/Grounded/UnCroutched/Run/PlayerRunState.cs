using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState {
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {}

    public override void EnterState() {
        _ctx._animationHandler.PlayAnimation("Run");
    }

    public override void CheckSwitchStates() {
        if(_ctx._isAttackPressed) {
            SwitchState(_factory.LightAttack1());
        }else if(!_ctx._movementInputDetected || !_ctx._isShiftPressed) {
            SwitchState(_factory.BreakRun());
        }
    }

    public override void UpdateState(){
        HandleMovement();
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
}
