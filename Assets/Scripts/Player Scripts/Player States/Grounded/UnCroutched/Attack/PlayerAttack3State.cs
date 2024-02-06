using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerBaseState{
    public PlayerAttack3State(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){}

    public override void EnterState(){
        _ctx._canFlipSprite = false;
        _ctx._isAttackPressed = false;
        _ctx._playerStats.currentAttackDmg = _ctx._playerStats.lightAttack3Dmg;
        _ctx._playerStats.currentAttackKnockback = _ctx._playerStats.lightAttack3KnockBack;
        _ctx._animationHandler.PlayAnimation("LightAttack3");
        _ctx._spriteRenderer.sortingOrder = 8;
    }

    public override void CheckSwitchStates() {
        _ctx._animationHandler.IfCurrentAnimationEndThen(EndAttack);
    }

    public override void ExitState(){
        _ctx._isAttackPressed = false;
        _ctx._attackCounter = 0;
        _ctx._playerStats.currentAttackDmg = 0;
        _ctx._playerStats.currentAttackKnockback = 0;
        _ctx._spriteRenderer.sortingOrder = 10;
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
