using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerBaseState {

    public PlayerWallSlideState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){
        
    }

    public override void EnterState(){
        Debug.Log("Wall Slide " + Time.time);
        HandleWallSlide();
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void ExitState(){
        _ctx._rb.velocity = Vector2.zero;
    }
    public override void CheckSwitchStates(){
        if(_ctx._isJumpPressed){
            SwitchState(_factory.WallJump());
        }else if(!_ctx._isDownKeyPressed){
            SwitchState(_factory.WallHang());
        } else if (_ctx._isClimbPressed){
            SwitchState(_factory.Climb());
        }
    }

    public override void InitializeSubState(){

    }

    private void HandleWallSlide(){
        _ctx._rb.velocity = new Vector2(100 * _ctx.direction, _ctx._playerStats.climbSlideSpeed *-1);
    }
}
