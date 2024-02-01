using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerBaseState {
    bool hardLand;
    public PlayerLandState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory, bool hardLand) : base(currentContext, playerStateFactory){
        this.hardLand = hardLand;
    }

    public override void CheckSwitchStates() {
        _ctx._animationHandler.IfCurrentAnimationEndThen(Idle);
    }

    public override void EnterState() {
        Debug.Log("Landed " + Time.time);
        _ctx._rb.velocity = Vector2.zero;
        if(hardLand){
            _ctx._animationHandler.PlayAnimation("Hard Land");
        } else {
            _ctx._animationHandler.PlayAnimation("Land");
        }
    }

    public override void ExitState(){
        
    }

    public override void InitializeSubState(){}

    public override void UpdateState() {
        CheckSwitchStates();
    }

    void Idle(){
        _ctx._playerStats.playerLanded = true;
        SwitchState(_factory.Idle());
    }
}
