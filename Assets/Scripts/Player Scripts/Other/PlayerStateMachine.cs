using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour {

    //reference variables
    public AnimationHandler _animationHandler;
    public Rigidbody2D _rb;
    public PlayerStats _playerStats;
    public PlayerBaseState _currentState;
    public PlayerStateFactory _states;
    public SpriteRenderer _spriteRenderer;
    public LedgeCheck _ledgeCheck;
    public PlayerHitBoxManager _hitBoxManager;
    [SerializeField] public GameObject _surroundingsCheck;
    


    //variables
    public float _movementX;
    public int direction;

    //player flags
    public bool _canJump;
    public bool _canMove;
    public bool _canFlipSprite;
    public bool _isInteracting;
    public bool _isAttacking;

    //Input Variables
    public bool _isJumpPressed;
    public bool _movementInputDetected;
    public float _movementRight;
    public float _movementLeft;
    public bool _isClimbPressed;
    public bool _isDownKeyPressed;
    public bool _isCrouchPressed;
    public bool _isShiftPressed;
    public bool _isAttackPressed;
    public int _attackCounter;


    private void Awake(){
        //set reference variables   
        _playerStats = GetComponent<PlayerStats>();
        _rb = GetComponent<Rigidbody2D>();
        _animationHandler = GetComponent<AnimationHandler>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _ledgeCheck = GetComponentInChildren<LedgeCheck>();
        //setup state
        _states = new PlayerStateFactory(this);
        //
    }

    private void Start(){
        _currentState = _states.Grounded();
        _currentState.EnterState();
    }

    private void FixedUpdate() {
        UpdateMovementInput();
        UpdateValues();
        _currentState.UpdateStates();
    }

    private void UpdateValues(){
        //_playerStats.isTouchingWallLeft = _playerStats.TouchingLeftWallCheck();
        //_playerStats.isTouchingWallRight = _playerStats.TouchingRightWallCheck();
        //_playerStats.isNearLedgeLeft = _playerStats.NearEdgeLeftCheck();
        //_playerStats.isNearLedgeRight = _playerStats.NearEdgeRightCheck();
        if(!_playerStats.isInAir && _canFlipSprite){
            if(_movementX < 0 || _playerStats.isTouchingWallLeft){
                _spriteRenderer.flipX = true;
            } else if(_movementX > 0 || _playerStats.isTouchingWallRight){
                _spriteRenderer.flipX = false;
            }
        }
        if(_spriteRenderer.flipX){
            direction = -1;
        } else {
            direction = 1;
        }
    }

    public void PlayerIsInteracting(){
        _isInteracting = true;
    }

    public void StopPlayerInteracting(){
        _isInteracting = false;
    }

    private void UpdateMovementInput(){
        _movementX = _movementLeft + _movementRight;
        if(_movementX == 0){
            _movementInputDetected = false;
        } else {
            _movementInputDetected = true;
        }
    }

    public void DisableGravity(){
        _rb.gravityScale = 0;
    }

    public void EnableGravity(){
        _rb.gravityScale = 1;
    }

    public void SwitchStateToGrounded(){
        _currentState.SwitchState(_states.Grounded());
    }

    public void TeleportPlayerObjectLedge(){
        if(_playerStats.isTouchingWallLeft){
            transform.position = new Vector2(transform.position.x - 0.337f, transform.position.y + 1.318f);
        } else if(_playerStats.isTouchingWallRight){
            transform.position = new Vector2(transform.position.x + 0.337f, transform.position.y + 1.318f);
        }
    }
    
    public void PlayerHasLanded(){
        _playerStats.playerLanded = true;
    }
    #region
    public void OnMoveRight(InputValue context){
        _movementRight = context.Get<float>();
    }

    public void OnMoveLeft(InputValue context){
        _movementLeft = context.Get<float>() * -1;
    }

    public void OnJump(InputValue context){
        float input = context.Get<float>();
        if(input > 0){
            _isJumpPressed = true;
        } else {
            _isJumpPressed = false;
        }
    }

    public void OnUpKey(InputValue context){
        float input = context.Get<float>();
        if(input > 0){
            _isClimbPressed = true;
        } else {
            _isClimbPressed = false;
        }
    }

    public void OnDownKey(InputValue context){
        float input = context.Get<float>();
        if(input > 0){
            _isDownKeyPressed = true;
        } else {
            _isDownKeyPressed = false;
        }
    }

    public void OnCrouch(InputValue context){
        float input = context.Get<float>();
        if(input > 0){
            _isCrouchPressed = true;
        } else {
            _isCrouchPressed = false;
        }
    }

    public void OnShift(InputValue context){
        float input = context.Get<float>();
        if(input > 0){
            _isShiftPressed = true;
        } else {
            _isShiftPressed = false;
        }
    }

    public void OnAttack(InputValue context){
        float input = context.Get<float>();
        if(_isAttacking){
            _isAttackPressed = false;
        } else {
            if(input > 0){
                _attackCounter++;
                _isAttackPressed = true;
            } else {
                _isAttackPressed = false;
            }
        }
    }
    #endregion
}
