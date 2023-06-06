using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState {
    protected bool _isRootState = false;
    protected bool _hasSuperState = false;
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _factory;
    protected PlayerBaseState _currentSubState;
    protected PlayerBaseState _currentSuperState;

    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory){
        _ctx = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void CheckSwitchStates();
    
    public abstract void ExitState();

    public abstract void InitializeSubState();

    public void UpdateStates(){
        if(_currentSubState != null) {
            _currentSubState.UpdateStates();
        }
        UpdateState();
    }

    protected void ExitStates(){
        ExitState();
        if(_currentSubState != null) {
            _currentSubState.ExitStates();
        }
    }

    public void SwitchState(PlayerBaseState newState){
        ExitState();
        newState.EnterState();
        if(_currentSuperState != null){
            _currentSuperState.SetSubState(newState);
        } else if(_isRootState){
            _ctx._currentState = newState;
        }
    }

    protected void SetSuperState(PlayerBaseState newSuperState){
        _currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState){
        _currentSubState = newSubState;
        newSubState.SetSuperState(this);
        _currentSubState.EnterState();
    }
}
