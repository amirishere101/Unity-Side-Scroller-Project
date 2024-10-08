using System;
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
    public PlayerBaseState ToWalk(){
        return new PlayerToWalkState(_context, this);
    }

    public PlayerBaseState Walk(){
        return new PlayerWalkState(_context, this);
    }

    public PlayerBaseState BreakWalk(){
        return new PlayerBreakWalkState(_context, this);
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

    public PlayerBaseState Land(bool hardLand){
        return new PlayerLandState(_context, this, hardLand);
    }

    public PlayerBaseState Crouch(){
        return new PlayerCrouchState(_context, this);
    }

    public PlayerBaseState UnCrouch(){
        return new PlayerUnCrouchedState(_context, this);
    }

    public PlayerBaseState ToCrouch(){
        return new ToCrouch(_context, this);
    }

    public PlayerBaseState OutCrouch(){
        return new OutCrouch(_context, this);
    }

    public PlayerBaseState CrouchIdle(){
        return new CrouchIdle(_context, this);
    }

    public PlayerBaseState CrouchWalk(){
        return new CrouchWalk(_context, this);
    }
    
    public PlayerBaseState ToRun(){
        return new PlayerToRunState(_context, this);
    }

    public PlayerBaseState BreakRun(){
        return new PlayerBreakRunState(_context, this);
    }

    public PlayerBaseState Run(){
        return new PlayerRunState(_context, this);
    }

    public PlayerBaseState LightAttack1(){
        return new PlayerAttack1State(_context, this);
    }

    public PlayerBaseState LightAttack2(){
        return new PlayerAttack2State(_context, this);
    }

    public PlayerBaseState LightAttack3(){
        return new PlayerAttack3State(_context, this);
    }
}
