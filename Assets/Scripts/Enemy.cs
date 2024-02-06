using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable {

    public float health = 100;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] AnimationHandler animationHandler;

    public float Health { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void OnHit(float damage, Vector2 knockback) {
        spriteRenderer.color = new Color(255, 172, 172);
        animationHandler.PlayAnimation("DummyHit");
        health -= damage;
        if(health < 0) {
            health = 0;
        }
        rb.AddForce(knockback, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * (knockback/3), ForceMode2D.Impulse);
        Invoke(nameof(ResetColor), 1.5f);
    }

    public void OnHit(float damage) {
        spriteRenderer.color = new Color(255, 172, 172);
        health -= damage;
        if(health < 0) {
            health = 0;
        }
        Invoke(nameof(ResetColor), 1.5f);
    }

    void ResetColor(){
        spriteRenderer.color = new Color(255, 255, 255);
    }
}
