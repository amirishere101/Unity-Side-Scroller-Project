using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchWalk : PlayerBaseState
{
    public CrouchWalk(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        Debug.Log("Crouch Walk " + Time.time);
        _ctx._animationHandler.PlayAnimation("Crouch Walk");
    }

    public override void UpdateState(){
        CheckSwitchStates();
        HandleCrouchWalk();
    }

    public override void CheckSwitchStates(){
        if(!_ctx._movementInputDetected) {
            SwitchState(_factory.CrouchIdle());
        }
    }

    private void HandleCrouchWalk(){
        _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.currentSpeed * 0.66f, _ctx._rb.velocity.y);
    }

    public override void ExitState(){}

    public override void InitializeSubState(){}
}
