using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<T> : MonoBehaviour where T : Enum
{
    protected Dictionary<T, BaseState<T>> States = new();
    protected BaseState<T> CurrentState;

    private void Start()
    {
        CreateStates();

        CurrentState.OnEnter();
    }

    private void Update()
    {
        CurrentState.UpdateState();
    }

    public void TransitionToState(T stateKey)
    {
        CurrentState.OnExit();

        BaseState<T> PreviousState;
        PreviousState = CurrentState;
        CurrentState = States[stateKey];


        CurrentState.OnEnter(PreviousState);
    }

    public abstract void CreateStates();
}
