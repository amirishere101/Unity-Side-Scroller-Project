using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCrouch : PlayerBaseState
{
    public ToCrouch(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        Debug.Log("Crouch Idle" + Time.time);
        _ctx._rb.velocity = Vector2.zero;
        _ctx._animationHandler.PlayAnimation("ToCrouch");
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    public override void CheckSwitchStates(){
        if(_ctx._isCrouchPressed){
            _ctx._animationHandler.IfCurrentAnimationEndThen(Idle);
        } else {
            SwitchState(_factory.OutCrouch());
        }
        if(_ctx._movementInputDetected){
            //ANIMATIONS NOT YET IMPLEMENTED
            //SwitchState(_factory.CrouchWalk());
        }
    }

    public override void ExitState(){}

    public override void InitializeSubState(){}

    void Idle(){
        SwitchState(_factory.CrouchIdle());
    }
}
