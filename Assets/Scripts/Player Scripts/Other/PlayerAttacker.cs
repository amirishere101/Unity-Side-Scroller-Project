using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour {
    [SerializeField] GameObject playerObject;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] public Collider2D lightAttack1Hitbox;
    [SerializeField] public Collider2D lightAttack2Hitbox;
    [SerializeField] public Collider2D lightAttack3Hitbox;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Enemy Hit!");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            Vector2 direction = (other.transform.position - playerObject.transform.position).normalized;
            enemy.OnHit(playerStats.currentAttackDmg, new Vector2(direction.x * playerStats.currentAttackKnockback, 2));
        }
    }
}
