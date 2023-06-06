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
        _ctx._rb.velocity = new Vector2(_ctx._rb.position.x, 0);
    }
    public override void CheckSwitchStates(){
        if(_ctx._isJumpPressed){
            SwitchState(_factory.WallJump());
        }
        if(!_ctx._isDownKeyPressed){
            SwitchState(_factory.WallHang());
        }
    }

    public override void InitializeSubState(){

    }

    private void HandleWallSlide(){
        _ctx._rb.velocity = new Vector2(0, _ctx._playerStats.climbSlideSpeed *-1);
    }
}
