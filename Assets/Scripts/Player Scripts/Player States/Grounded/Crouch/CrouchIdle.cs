using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchIdle : PlayerBaseState
{
    public CrouchIdle(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        _ctx._animationHandler.PlayAnimation("Crouch");
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        if(!_ctx._isCrouchPressed){
            //ANIMATIONS NOT YET IMPLEMENTED
            SwitchState(_factory.OutCrouch());
        }
    }

    public override void ExitState(){}

    public override void InitializeSubState(){}
}
