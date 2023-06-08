using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchIdle : PlayerBaseState
{
    public CrouchIdle(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        Debug.Log("Crouch Idle" + Time.time);
        _ctx._rb.velocity = Vector2.zero;
        _ctx._animationHandler.PlayAnimation("Crouch");
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        if(_ctx._movementInputDetected){
            SwitchState(_factory.CrouchWalk());
        }
    }

    public override void ExitState(){}

    public override void InitializeSubState(){}
}
