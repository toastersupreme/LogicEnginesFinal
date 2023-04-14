using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


[Serializable]
public class StateMachine<T>
{
    [SerializeField] private List<AState<T>> _states;
    private T owner;

    [SerializeField] private AState<T> CurrentState;
    [SerializeField] private AIStates  PreviousStateType;

    [SerializeField] private AState<T> GlobalState;

    public void SetOwner(T owner)
    {
        this.owner = owner;
    }

    public void ChangeState(AIStates stateType)
    {
        AState<T> newState = _states.Find(state => state.StateType == stateType);
        Assert.IsNotNull(newState, "StateMachine.ChangeState: newState is null");

        if(CurrentState)
        {
            PreviousStateType = CurrentState.StateType;
            CurrentState.OnExit(owner);

        }
        CurrentState = newState;
        CurrentState.OnEnter(owner);
    }
    public void RevertState()
    {
        ChangeState(PreviousStateType);
    }
    public bool IsInState(AIStates stateType)
    {
        return CurrentState.StateType == stateType;
    }

    public void Update()
    {
        if (GlobalState) GlobalState.OnExecute(owner);
        if (CurrentState) CurrentState.OnExecute(owner);
    }
    public bool HandleMessage()
    {
        throw new System.NotImplementedException();
    }
}
