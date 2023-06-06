using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerBaseState {

    public PlayerWallGrabState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {
        _isRootState = true;
        InitializeSubState();
    }

    public override void EnterState() {
        Debug.Log("Wall Grab State " + Time.time);
        _ctx._playerStats.isClimbing = true;
    }

    public override void UpdateState() {
        CheckSwitchStates();
    }

    public override void CheckSwitchStates() {
        if(_ctx._playerStats.isInAir){
            SwitchState(_factory.Aerial());
        }
        if(_ctx._isParkourPressed){
            SwitchState(_factory.Grounded());
        }
    }

    public override void ExitState() {
        _ctx.EnableGravity();
        _ctx._playerStats.isClimbing = false;
    }

    public override void InitializeSubState() {
        SetSubState(_factory.WallHang());
    }
}
