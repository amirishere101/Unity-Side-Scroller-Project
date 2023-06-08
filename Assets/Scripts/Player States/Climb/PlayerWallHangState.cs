using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallHangState : PlayerBaseState {

    public PlayerWallHangState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){
        
    }

    public override void EnterState(){
        Debug.Log("Wall Hang State  " + Time.time);
        _ctx._animationHandler.PlayAnimation("WallHang");
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void ExitState(){
    }
    
    public override void CheckSwitchStates(){
        if(_ctx._playerStats.isNearLedgeLeft || _ctx._playerStats.isNearLedgeRight){
            SwitchState(_factory.LedgeHang());
        }
        if(_ctx._isJumpPressed){
            SwitchState(_factory.WallJump());
        }
        if(_ctx._isClimbPressed){
            SwitchState(_factory.Climb());
        } else if(_ctx._isDownKeyPressed){
            SwitchState(_factory.WallSlide());
        }
    }

    public override void InitializeSubState(){

    }
}
