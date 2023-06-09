using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCheck : MonoBehaviour {
    public BoxCollider2D LedgeRight;
    public BoxCollider2D LedgeLeft;
    PlayerStats _playerStats;
    PlayerStateMachine _stateMachine;

    void Awake(){
        _playerStats = GetComponentInParent<PlayerStats>();
        _stateMachine = GetComponentInParent<PlayerStateMachine>();
    }
    void Start(){
        LedgeLeft.isTrigger = true;
        LedgeRight.isTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Test");
        if((other.tag == "Wall" && _playerStats.isTouchingWallLeft && _stateMachine._spriteRenderer.flipX == true)){
            Debug.Log("Test1" + Time.time);
            _playerStats.isNearLedgeLeft = true;
            LedgeLeft.isTrigger = false;
        } else if(other.tag == "Wall" && _playerStats.isTouchingWallRight && _stateMachine._spriteRenderer.flipX == false){
            Debug.Log("Test2" + Time.time);
            _playerStats.isNearLedgeRight = true;
            LedgeRight.isTrigger = false;
        } 
    }

    public void ResetTriggers(){
        _playerStats.isNearLedgeRight = false;
        _playerStats.isNearLedgeLeft = false;
        LedgeLeft.isTrigger = true;
        LedgeRight.isTrigger = true;
    }
}
