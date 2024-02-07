using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerBaseState{
    
    public PlayerLedgeClimbState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){
    }

    public override void CheckSwitchStates()
    {
    }

    public override void EnterState() {
        Debug.Log("Ledge Climb" + Time.time);
        _ctx._rb.velocity = Vector2.zero;
        _ctx._animationHandler.PlayAnimation("Ledge Climb");
    }

    public override void ExitState(){
    }

    public override void InitializeSubState()
    {
    }

    public override void UpdateState()
    {
    }
}
