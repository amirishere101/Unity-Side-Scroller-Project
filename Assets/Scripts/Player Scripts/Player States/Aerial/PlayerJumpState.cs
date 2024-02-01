using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState {
    float jumpTime = 0.2f;
    float jumpTimer;

    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){
    }

    public override void EnterState(){
        Debug.Log("Player is Jumping " + Time.time);
        _ctx.EnableGravity();
        HandleJumping();
        jumpTimer = jumpTime;
        _ctx._canJump = false;
        _ctx._playerStats.isJumping = true;
        _ctx._animationHandler.PlayAnimation("Jump");
    }

    public override void UpdateState(){
        CheckSwitchStates();
        jumpTimer -= Time.deltaTime;
        if(jumpTimer < 0 && _ctx._rb.velocity.y < 0f){
            _ctx._playerStats.isInAir = true;
        }
    }

    public override void ExitState(){
        _ctx._playerStats.isJumping = false;
    }
    public override void CheckSwitchStates(){
        if(_ctx._rb.velocity.y <= 0f){
            SwitchState(_factory.Falling());
        } 
    }

    public override void InitializeSubState(){

    }

    private void HandleJumping(){
        _ctx._rb.velocity = new Vector2(_ctx._playerStats.currentSpeed * 2 * _ctx._movementX, _ctx._playerStats.jumpVelocity);
    }
}
