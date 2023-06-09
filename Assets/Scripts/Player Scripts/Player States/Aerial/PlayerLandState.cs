using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerBaseState {
    private float landTime = 0.2f;
    private float landTimer;
    public PlayerLandState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void CheckSwitchStates() {
    }

    public override void EnterState() {
        Debug.Log("Landed " + Time.time);
        //play land animation
        landTimer = landTime;
        _ctx._rb.velocity = Vector2.zero;
        _ctx._animationHandler.PlayAnimation("Land");
    }

    public override void ExitState(){
        _ctx._playerStats.playerLanded = false;
    }

    public override void InitializeSubState(){}

    public override void UpdateState() {
        landTimer -= Time.deltaTime;
        CheckSwitchStates();
    }
}
