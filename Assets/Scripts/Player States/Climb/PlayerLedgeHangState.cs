using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeHangState : PlayerBaseState {

    public PlayerLedgeHangState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){
        
    }
    public override void EnterState(){
        Debug.Log("Ledge Hang" + Time.time);
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void ExitState(){

    }
    public override void CheckSwitchStates(){
        if(_ctx._isJumpPressed && ((_ctx._playerStats.isTouchingWallRight && _ctx._movementLeft < 0) || (_ctx._playerStats.isTouchingWallLeft && _ctx._movementRight > 0))){
            SwitchState(_factory.WallJump());
        } else if(_ctx._isJumpPressed){
            SwitchState(_factory.LedgeClimb());
        } else if(_ctx._isDownKeyPressed){
            SwitchState(_factory.WallSlide());
        }
    }

    public override void InitializeSubState(){

    }
}
