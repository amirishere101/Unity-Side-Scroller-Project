using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerBaseState {
    public PlayerInAirState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {
        _isRootState = true;
        InitializeSubState();
    }

    public override void CheckSwitchStates() {
        if((_ctx._playerStats.isTouchingWallLeft && _ctx._movementLeft < 0) || (_ctx._playerStats.isTouchingWallRight && _ctx._movementRight > 0) 
        || (_ctx._playerStats.isJumping &&(_ctx._playerStats.isTouchingWallLeft || _ctx._playerStats.isTouchingWallRight))){
            SwitchState(_factory.WallGrab());
        } else if(_ctx._playerStats.playerLanded){
            SwitchState(_factory.Grounded());
        }
    }

    public override void EnterState() {
        Debug.Log("In Air " + Time.time);
        _ctx._playerStats.isInAir = true;
        _ctx._playerStats.playerLanded = false;
    }

    public override void ExitState() {
        _ctx._playerStats.isInAir = false;
        _ctx._playerStats.inAirTimer = 0;
    }

    public override void InitializeSubState() {
        if(_ctx._isJumpPressed && _ctx._rb.velocity.y == 0) {
            SetSubState(_factory.Jump());
        } else {
            SetSubState(_factory.Falling());
        }
    }

    public override void UpdateState() {
        _ctx._playerStats.inAirTimer += Time.deltaTime;
        CheckSwitchStates();
    }
}
