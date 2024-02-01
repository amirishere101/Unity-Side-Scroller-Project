using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerBaseState{
    public PlayerAttack3State(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        _ctx._canFlipSprite = false;
        _ctx._isAttackPressed = false;
        _ctx._animationHandler.PlayAnimation("LightAttack3");
        if(_ctx._knife != null) {
            _ctx._knife.EnableKnifeHitbox();
        }
    }

    public override void CheckSwitchStates() {
        _ctx._animationHandler.IfCurrentAnimationEndThen(EndAttack);
    }

    public override void ExitState(){
        _ctx._isAttackPressed = false;
        _ctx._attackCounter = 0;
        if(_ctx._knife != null){
            _ctx._knife.DisableKnifeHitBox();
        }
    }

    public override void InitializeSubState(){
    }

    public override void UpdateState(){
        CheckSwitchStates();
    }

    void EndAttack(){
        _ctx._canFlipSprite = true;
        SwitchState(_factory.Idle());
    }
}
