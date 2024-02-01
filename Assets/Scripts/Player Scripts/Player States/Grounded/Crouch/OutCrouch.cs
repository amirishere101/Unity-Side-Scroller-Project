using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutCrouch : PlayerBaseState
{
    public OutCrouch(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        _ctx._animationHandler.PlayAnimation("OutCrouch");
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        _ctx._animationHandler.IfCurrentAnimationEndThen(UnCrouch);
    }

    public override void ExitState(){}

    public override void InitializeSubState(){}

    void UnCrouch(){
        _currentSuperState.SwitchState(_factory.Grounded());
    }
}
