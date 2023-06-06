using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    
    public LayerMask groundLayer;
    public LayerMask ledgeDetector;

    [Header("Stats")]
    public float maxStamina;
    public float currentStamina;

    [Header("Movement")]
    public float currentSpeed;
    public float walkSpeed;
    public float runSpeed;
    public float climbSpeed;
    public float climbSlideSpeed;

    [Header("Jumping/Falling")]
    public float jumpVelocity;
    public Vector2 wallJumpPower;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float maxFallVelocity = -40;

    [Header("RayCasts")]
    [SerializeField] public float groundDetectorLength = 1;
    [SerializeField] public float WallDetectorLength = 1;
    [SerializeField] public float EdgeDetectorHeight = 1;
    [SerializeField] public float WallDetectorOffsetFromCenter = 1;
    [SerializeField] public float offsetFromTransform = 0.2f;
    [SerializeField] public float middleOfSprite = 0;

    [Header("Player Flags")]
    public bool isGrounded;
    public bool isClimbing = false;
    public bool isTouchingWallRight = false;
    public bool isTouchingWallLeft = false;
    public bool isNearLedgeRight = false;
    public bool isNearLedgeLeft = false;
    public bool isExhausted = false;
    public bool isWallJumping = false;
    public bool isInAir = false;
    public bool isJumping = false;
    public bool playerLanded;
    public float inAirTimer = 0;

    public void DrainStamina(float exhaust){
        currentStamina -= exhaust;
        if(currentStamina <= 0){
            isExhausted = true;
            currentStamina = 0;
        }
    }

    public void ReplenishStamina(){
        currentStamina = maxStamina;
        isExhausted = false;
    }

    public bool GroundedCheck(){
        Debug.DrawRay(new Vector2(transform.position.x + middleOfSprite, transform.position.y - offsetFromTransform), Vector2.down * groundDetectorLength, Color.red);
        return Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - offsetFromTransform), Vector2.down, groundDetectorLength, groundLayer);
    }

    public bool TouchingRightWallCheck(){
        Debug.DrawRay(new Vector2(transform.position.x + WallDetectorOffsetFromCenter + middleOfSprite, transform.position.y - offsetFromTransform), Vector2.right * WallDetectorLength, Color.red, 3);
        return Physics2D.Raycast(new Vector2(transform.position.x + WallDetectorOffsetFromCenter, transform.position.y - offsetFromTransform), Vector2.right, WallDetectorLength, ledgeDetector);
    }

    public bool TouchingLeftWallCheck(){
        Debug.DrawRay(new Vector2(transform.position.x - WallDetectorOffsetFromCenter + middleOfSprite, transform.position.y - offsetFromTransform), Vector2.left * WallDetectorLength, Color.red, 3);
        return Physics2D.Raycast(new Vector2(transform.position.x - WallDetectorOffsetFromCenter, transform.position.y - offsetFromTransform), Vector2.left, WallDetectorLength, ledgeDetector);
    }

    public bool NearEdgeRightCheck(){
        Debug.DrawRay(new Vector2(transform.position.x + WallDetectorOffsetFromCenter + middleOfSprite, transform.position.y + EdgeDetectorHeight), Vector2.right * WallDetectorLength, Color.red);
        return !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + EdgeDetectorHeight), Vector2.right, WallDetectorLength, ledgeDetector) && isTouchingWallRight;
    }

    public bool NearEdgeLeftCheck(){
        Debug.DrawRay(new Vector2(transform.position.x - WallDetectorOffsetFromCenter + middleOfSprite, transform.position.y + EdgeDetectorHeight), Vector2.left * WallDetectorLength, Color.red);
        return !Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + EdgeDetectorHeight), Vector2.left, WallDetectorLength, ledgeDetector) && isTouchingWallLeft;
    }
}
