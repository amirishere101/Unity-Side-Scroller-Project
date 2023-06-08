using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory {

    PlayerStateMachine _context;

    public PlayerStateFactory(PlayerStateMachine currentContext){
        _context = currentContext;
    }

    public PlayerBaseState Idle(){
        return new PlayerIdleState(_context, this);
    }

    public PlayerBaseState Walk(){
        return new PlayerWalkState(_context, this);
    }

    public PlayerBaseState Climb(){
        return new PlayerClimbState(_context, this);
    }

    public PlayerBaseState LedgeHang(){
        return new PlayerLedgeHangState(_context, this);
    }

    public PlayerBaseState WallHang(){
        return new PlayerWallHangState(_context, this);
    }

    public PlayerBaseState WallSlide(){
        return new PlayerWallSlideState(_context, this);
    }

    public PlayerBaseState Grounded(){
        return new PlayerGroundedState(_context, this);
    }

    public PlayerBaseState Jump(){
        return new PlayerJumpState(_context, this);
    }

    public PlayerBaseState WallGrab(){
        return new PlayerWallGrabState(_context, this);
    }

    public PlayerBaseState Aerial(){
        return new PlayerInAirState(_context, this);
    }

    public PlayerBaseState Falling(){
        return new PlayerFallingState(_context, this);
    }

    public PlayerBaseState WallJump(){
        return new PlayerWallJumpState(_context, this);
    }

    public PlayerBaseState LedgeClimb(){
        return new PlayerLedgeClimbState(_context, this);
    }

    public PlayerBaseState Land(){
        return new PlayerLandState(_context, this);
    }

    public PlayerBaseState Crouch(){
        return new PlayerCrouchState(_context, this);
    }

    public PlayerBaseState UnCrouch(){
        return new PlayerUnCrouchedState(_context, this);
    }

    public PlayerBaseState CrouchIdle(){
        return new CrouchIdle(_context, this);
    }

    public PlayerBaseState CrouchWalk(){
        return new CrouchWalk(_context, this);
    }

    public PlayerBaseState Run(){
        return new PlayerSprint(_context, this);
    }

    public PlayerBaseState KnifeAttack1(){
        return new PlayerAttackState(_context, this);
    }

    public PlayerBaseState KnifeAttackCooldown(){
        return new PlayerAttackCooldownState(_context, this);
    }
}
