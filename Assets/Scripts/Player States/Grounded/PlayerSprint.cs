using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : PlayerBaseState
{
    public PlayerSprint(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {
    }

    public override void CheckSwitchStates() {
        if(!_ctx._movementInputDetected) {
            SwitchState(_factory.Idle());
        } else if(!_ctx._isShiftPressed){
            SwitchState(_factory.Walk());
        }
    }

    public override void EnterState() {
        Debug.Log("Player is Sprinting " + Time.time);
        _ctx._animationHandler.PlayAnimation("Run");
        _ctx._playerStats.currentSpeed = _ctx._playerStats.runSpeed;
    }

    public override void ExitState() {
        _ctx._rb.velocity = Vector2.zero;
        _ctx._playerStats.currentSpeed = 0;
    }

    public override void InitializeSubState() {}

    public override void UpdateState(){
        CheckSwitchStates();
        HandleMovement();
    }

    private void HandleMovement(){
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.runSpeed, _ctx._rb.velocity.y); 
    }
}
