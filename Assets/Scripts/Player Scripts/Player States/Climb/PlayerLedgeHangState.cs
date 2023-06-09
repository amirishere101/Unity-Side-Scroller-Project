using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeHangState : PlayerBaseState {
    LedgeCheck _ledgeCheck;

    public PlayerLedgeHangState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){
        _ledgeCheck = _ctx._ledgeCheck;
    }
    public override void EnterState(){
        Debug.Log("Ledge Hang" + Time.time);
        _ctx._rb.velocity = Vector2.zero;
    }

    public override void UpdateState(){
        CheckSwitchStates();
        HandleLedgeHang();
    }

    public override void ExitState(){
        _ctx._rb.velocity = Vector2.zero;
        _ledgeCheck.ResetTriggers();
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

    void HandleLedgeHang(){
        if(_ctx._playerStats.isNearLedgeLeft || _ctx._playerStats.isNearLedgeRight){
            _ctx._rb.velocity = new Vector2(20 * _ctx.direction, -10);
        }else{
            _ctx._rb.velocity = Vector2.zero;
        }
    }
}
