using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    PlayerStats _playerStats;

    void Awake(){
        _playerStats = GetComponentInParent<PlayerStats>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Ground" && !_playerStats.isClimbing){
            _playerStats.isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Ground"){
            _playerStats.isGrounded = false;
        }
    }

}
