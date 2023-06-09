using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerBaseState {

    public PlayerClimbState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base (currentContext, playerStateFactory){

    }
    public override void EnterState(){
        Debug.Log("Climb State " + Time.time);
        HandleClimb();
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void ExitState(){
        _ctx._rb.velocity = Vector2.zero;
    }

    public override void CheckSwitchStates(){
        if(_ctx._playerStats.isNearLedgeLeft || _ctx._playerStats.isNearLedgeRight){
            SwitchState(_factory.LedgeHang());
        }
        if(_ctx._isJumpPressed){
            SwitchState(_factory.WallJump());
        }
        if(!_ctx._isClimbPressed){
            SwitchState(_factory.WallHang());
        }
    }

    public override void InitializeSubState(){

    }

    private void HandleClimb(){
        _ctx._rb.velocity = new Vector2(100 * _ctx.direction, _ctx._playerStats.climbSpeed);
    }
}
