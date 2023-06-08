using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnCrouchedState : PlayerBaseState
{
    public PlayerUnCrouchedState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){
        _isRootState = true;
        InitializeSubState();
    }

    public override void EnterState(){
        Debug.Log("UnCrouched " + Time.time);
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        if(_ctx._isCrouchPressed){
            SwitchState(_factory.Crouch());
        }
    }

    public override void InitializeSubState(){
        if(!_ctx._movementInputDetected){
            SetSubState(_factory.Idle());
        } else {
            SetSubState(_factory.Walk());
        }
    }

    public override void ExitState(){}
}
