using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState {
    float _coyoteTime = 0.15f;
    float _landTime = 0.3f;
    float _hardLandTime = 0.5f;

    public PlayerFallingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) {
    }

    public override void EnterState() {
        Debug.Log("Falling " + Time.time);
        _ctx._animationHandler.PlayAnimation("Jump To Fall");
    }

    public override void CheckSwitchStates() {
        if(_ctx._playerStats.inAirTimer < _coyoteTime && _ctx._isJumpPressed){
            SwitchState(_factory.Jump());
        }

        if(_ctx._playerStats.isGrounded && _ctx._playerStats.inAirTimer > _landTime && _ctx._playerStats.inAirTimer < _hardLandTime){
            SwitchState(_factory.Land(false));
        } else if(_ctx._playerStats.isGrounded && _ctx._playerStats.inAirTimer >= _hardLandTime){
            //change back to true here when the animation is fixed :)
            SwitchState(_factory.Land(false));
        }else if(_ctx._playerStats.isGrounded){
            _ctx._playerStats.playerLanded = true;
        }
    }

    public override void ExitState() {
    }

    public override void InitializeSubState()
    {

    }

    public override void UpdateState() {
        CheckSwitchStates();
        HandleFall();
    }

    void HandleFall(){
       _ctx._rb.velocity = new Vector2(_ctx._movementX * _ctx._playerStats.currentSpeed, _ctx._rb.velocity.y);
    }
}
