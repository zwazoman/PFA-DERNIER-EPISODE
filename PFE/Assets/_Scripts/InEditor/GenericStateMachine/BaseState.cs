using System;
using UnityEngine;

public abstract class BaseState<T> where T : Enum
{
    public BaseState(T key)
    {
        StateKey = key;
    }

    public T StateKey { get; private set; }

    public abstract void OnEnter(BaseState<T> PreviousState = null);
    public abstract void UpdateState();
    public abstract void OnExit();

    //Physics
    public virtual void FixedUpdate() { }

    //Collisions
    public virtual void OnTriggerEnter(Collider other) { }
    public virtual void OnTriggerStay(Collider other) { }
    public virtual void OnTriggerExit(Collider other) { }

}
