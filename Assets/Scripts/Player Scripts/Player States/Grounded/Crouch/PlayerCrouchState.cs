using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    public PlayerCrouchState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){
        _isRootState = true;
        InitializeSubState();
    }

    public override void EnterState() {
        Debug.Log("Crouch " + Time.time);
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates() {
    }

    public override void InitializeSubState(){
        if(!_ctx._movementInputDetected){
            SetSubState(_factory.ToCrouch());
        } else {
            SetSubState(_factory.CrouchWalk());
        }
    }

    public override void ExitState(){}

}
