using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBoxManager : MonoBehaviour {

    [SerializeField] PlayerAttacker playerAttacker;
    [SerializeField] PlayerStateMachine _ctx;

    public void EnableLightAttack1HitBox(){
        if(_ctx._spriteRenderer.flipX){
            playerAttacker.lightAttack1Hitbox.enabled = true;
        } else {
            playerAttacker.lightAttack1Hitbox.offset = new Vector2(playerAttacker.lightAttack1Hitbox.offset.x * -1, playerAttacker.lightAttack1Hitbox.offset.y);
            playerAttacker.lightAttack1Hitbox.enabled = true;
        }
    }

    public void DisableLightAttack1Hitbox(){
        if(_ctx._spriteRenderer.flipX){
            playerAttacker.lightAttack1Hitbox.enabled = false;
        } else {
            playerAttacker.lightAttack1Hitbox.offset = new Vector2(playerAttacker.lightAttack1Hitbox.offset.x * -1, playerAttacker.lightAttack1Hitbox.offset.y);
            playerAttacker.lightAttack1Hitbox.enabled = false;
        }
    }

    public void EnableLightAttack2HitBox(){
        if(_ctx._spriteRenderer.flipX){
            playerAttacker.lightAttack2Hitbox.enabled = true;
        } else {
            playerAttacker.lightAttack2Hitbox.offset = new Vector2(playerAttacker.lightAttack2Hitbox.offset.x * -1, playerAttacker.lightAttack2Hitbox.offset.y);
            playerAttacker.lightAttack2Hitbox.enabled = true;
        }
    }

    public void DisableLightAttack2Hitbox(){
        if(_ctx._spriteRenderer.flipX){
            playerAttacker.lightAttack2Hitbox.enabled = false;
        } else {
            playerAttacker.lightAttack2Hitbox.offset = new Vector2(playerAttacker.lightAttack2Hitbox.offset.x * -1, playerAttacker.lightAttack2Hitbox.offset.y);
            playerAttacker.lightAttack2Hitbox.enabled = false;
        }
    }

    public void EnableLightAttack3HitBox(){
        if(_ctx._spriteRenderer.flipX){
            playerAttacker.lightAttack3Hitbox.enabled = true;
        } else {
            playerAttacker.lightAttack3Hitbox.offset = new Vector2(playerAttacker.lightAttack3Hitbox.offset.x * -1, playerAttacker.lightAttack3Hitbox.offset.y);
            playerAttacker.lightAttack3Hitbox.enabled = true;
        }
    }

    public void DisableLightAttack3Hitbox(){
        if(_ctx._spriteRenderer.flipX){
            playerAttacker.lightAttack3Hitbox.enabled = false;
        } else {
            playerAttacker.lightAttack3Hitbox.offset = new Vector2(playerAttacker.lightAttack3Hitbox.offset.x * -1, playerAttacker.lightAttack3Hitbox.offset.y);
            playerAttacker.lightAttack3Hitbox.enabled = false;
        }
    }

    
}
