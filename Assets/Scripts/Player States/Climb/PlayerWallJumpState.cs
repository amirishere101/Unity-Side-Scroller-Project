using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerBaseState {
    float _wallJumpDirection = -1;
    public PlayerWallJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {
    }

    public override void EnterState() {
        Debug.Log("Wall Jumping " + Time.time);
        _ctx.EnableGravity();
        HandleWallJump();
        _ctx._animationHandler.PlayAnimation("Jump");
    }

    public override void CheckSwitchStates(){
        
    }

    public override void ExitState()
    {
    }

    public override void InitializeSubState()
    {
    }

    public override void UpdateState() {
        if(_ctx._rb.velocity.y <= 0f){
            _ctx._playerStats.isInAir = true;
        }
    }

    private void HandleWallJump(){
        if(_ctx._playerStats.isTouchingWallLeft){
            _wallJumpDirection = 1;
            _ctx._spriteRenderer.flipX = false;
        } else if(_ctx._playerStats.isTouchingWallRight){
            _wallJumpDirection = -1;
            _ctx._spriteRenderer.flipX = true;
        }
        _ctx._rb.velocity = new Vector2(_wallJumpDirection * _ctx._playerStats.wallJumpPower.x, _ctx._playerStats.wallJumpPower.y);
    }
}
