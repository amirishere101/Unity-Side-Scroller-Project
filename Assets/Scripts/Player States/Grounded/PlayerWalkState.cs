using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState {

    public PlayerWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory) {}

    public override void EnterState(){
        Debug.Log("Player is Walking " + Time.time);
        _ctx._animationHandler.PlayAnimation("Walk");
        _ctx._playerStats.currentSpeed = _ctx._playerStats.walkSpeed;
    }

    public override void UpdateState(){
        CheckSwitchStates();
        HandleMovement();
    }

    public override void CheckSwitchStates(){
        if(!_ctx._movementInputDetected) {
            SwitchState(_factory.Idle());
        } else if(_ctx._isShiftPressed){
            SwitchState(_factory.Run());
        }
    }

    public override void ExitState(){
        _ctx._rb.velocity = Vector2.zero;
        _ctx._playerStats.currentSpeed = 0;
    }

    private void HandleMovement(){
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.walkSpeed, _ctx._rb.velocity.y); 
    }

    public override void InitializeSubState(){}

}
