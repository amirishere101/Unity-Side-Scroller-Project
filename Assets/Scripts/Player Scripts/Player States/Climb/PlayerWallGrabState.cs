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
        _ctx._animationHandler.PlayAnimation("WallHang");
        _ctx._playerStats.isClimbing = true;
        _ctx._rb.velocity = new Vector2(50* _ctx._movementX, 0);
    }

    public override void UpdateState() {
        CheckSwitchStates();
    }

    public override void CheckSwitchStates() {
        if(_ctx._playerStats.isInAir){
            SwitchState(_factory.Aerial());
        }
    }

    public override void ExitState() {
        _ctx._playerStats.isClimbing = false;
    }

    public override void InitializeSubState() {
        if(!_ctx._playerStats.playerLanded){
            SetSubState(_factory.WallSlide());
        } else {
            SetSubState(_factory.WallHang());
        }
    }
}
