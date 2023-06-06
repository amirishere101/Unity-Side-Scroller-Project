using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerBaseState {

    public PlayerGroundedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){
        _isRootState = true;
        InitializeSubState();
    }

    public override void EnterState(){
        Debug.Log("Player is Grounded " + Time.time);
        _ctx._canJump = true;
        _ctx._canFlipSprite = true;
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        if(!_ctx._playerStats.isGrounded || _ctx._playerStats.isInAir || _ctx._isJumpPressed){
            SwitchState(_factory.Aerial());
        }
        if(_ctx._isParkourPressed && _ctx._canScaleWall){
            SwitchState(_factory.WallGrab());
        }
    }

    public override void InitializeSubState(){
        SetSubState(_factory.UnCrouch());
    }

    public override void ExitState(){
        _ctx._canFlipSprite = false;
    }
}
