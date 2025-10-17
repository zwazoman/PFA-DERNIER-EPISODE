using System;
using UnityEngine;

public abstract class BaseState<T> where T : Enum
{
    public BaseState(T key)
    {
        StateKey = key;
    }

    public T StateKey { get; private set; }

    public abstract void OnEnter();
    public abstract void UpdateState();
    public abstract void OnExit();
}
