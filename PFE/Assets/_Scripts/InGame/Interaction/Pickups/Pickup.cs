using System;
using UnityEngine;

public class Pickup : Interactable
{
    #region Events

    public event Action OnDropped;
    public event Action OnPickedUp;

    #endregion

    [SerializeField] Collider _coll;
    [SerializeField] Rigidbody _rb;

    protected override void Awake()
    {
        base.Awake();

        TryGetComponent(out _coll);
        TryGetComponent(out _rb);
    }

    public override void Interact(PlayerInteraction interaction)
    {
        base.Interact(interaction);

        TryPickup(interaction);
    }

    protected virtual void TryPickup(PlayerInteraction interaction)
    {
        //désactive gravité collisions etc

        print("picked up");
        isInteractable = false;
        _coll.enabled = false;
        _rb.isKinematic = true;
        StopHover();

        OnPickedUp?.Invoke();
    }

    public virtual void Drop()
    {
        //réactive tout

        transform.parent = null;
        isInteractable = true;
        _coll.enabled = true;
        _rb.isKinematic = false;
        
        OnDropped?.Invoke();
    }
}
