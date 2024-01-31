using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreakWalkState : PlayerBaseState {

    public PlayerBreakWalkState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory) {}

    public override void EnterState(){
        Debug.Log("Stop Walking" + Time.time);
        _ctx._animationHandler.PlayAnimation("BreakWalk");
        _ctx._playerStats.currentSpeed = _ctx._playerStats.walkSpeed;
    }

    public override void UpdateState(){
        HandleMovement();
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        _ctx._animationHandler.IfCurrentAnimationEndThen(Idle);
    }

    public override void ExitState(){
        _ctx._rb.velocity = Vector2.zero;
        _ctx._playerStats.currentSpeed = 0;
    }

    private void HandleMovement(){
        _ctx._playerStats.currentSpeed -= _ctx._playerStats.walkAcceleration * Time.deltaTime;
        _ctx._playerStats.currentSpeed = Mathf.Clamp(_ctx._playerStats.currentSpeed, 0, _ctx._playerStats.walkSpeed);
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.currentSpeed, _ctx._rb.velocity.y);
    }

    void Idle(){
        SwitchState(_factory.Idle());
    }

    public override void InitializeSubState(){}

}
