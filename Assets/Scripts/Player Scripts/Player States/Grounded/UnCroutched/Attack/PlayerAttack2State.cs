using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2State : PlayerBaseState{
    bool combo;
    bool endAttack;
    public PlayerAttack2State(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory){
        combo = false;
    }

    public override void EnterState(){
        _ctx._canFlipSprite = false;
        _ctx._isAttackPressed = false;
        _ctx._playerStats.currentAttackDmg = _ctx._playerStats.lightAttack2Dmg;
        _ctx._playerStats.currentAttackKnockback = _ctx._playerStats.lightAttack2KnockBack;
        _ctx._animationHandler.PlayAnimation("LightAttack2");
    }

    public override void CheckSwitchStates() {
        if(endAttack){
            _ctx._animationHandler.IfCurrentAnimationEndThen(Idle);
        } else {
            if(combo){
                _ctx._animationHandler.IfCurrentAnimationEndThen(Combo);
            } else {
                _ctx._animationHandler.IfCurrentAnimationEndThen(EndAttack);
            }
        }
    }

    public override void ExitState(){
        _ctx._playerStats.currentAttackDmg = 0;
        _ctx._playerStats.currentAttackKnockback = 0;
    }

    public override void InitializeSubState(){
    }

    public override void UpdateState(){
        //float may need changing based on the animation length
        if(_ctx._animationHandler.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >=0.4f && (_ctx._isAttackPressed || _ctx._attackCounter >= 3)){
            combo = true;
        } else {
            _ctx._isAttackPressed = false;
        }
        CheckSwitchStates();
    }

    void Combo(){
        SwitchState(_factory.LightAttack3());
    }

    void Idle(){
        _ctx._canFlipSprite = true;
        SwitchState(_factory.Idle());
    }

    void EndAttack(){
        _ctx._attackCounter = 0;
        _ctx._animationHandler.PlayAnimation("LightAttack2Recovery");
        endAttack = true;
    }

    
}
