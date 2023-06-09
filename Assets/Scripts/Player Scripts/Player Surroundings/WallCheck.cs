using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour {
    PlayerStats _playerStats;
    PlayerStateMachine _stateMachine;

    void Awake(){
        _playerStats = GetComponentInParent<PlayerStats>();
        _stateMachine = GetComponentInParent<PlayerStateMachine>();
    }
    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Wall" && _stateMachine._spriteRenderer.flipX == false){
            _playerStats.isTouchingWallRight = true;
            _stateMachine._canFlipSprite = false;
        } else if(other.tag == "Wall" && _stateMachine._spriteRenderer.flipX == true){
            _playerStats.isTouchingWallLeft = true;
            _stateMachine._canFlipSprite = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Wall"){
            _playerStats.isTouchingWallRight = false;
           _playerStats.isTouchingWallLeft = false;
            _stateMachine._canFlipSprite = true;
        }
    }
   
}
