using System;
using UnityEngine;

public class Pickup : Interactable
{
    #region Events

    public event Action OnDropped;
    public event Action OnPickedUp;

    #endregion

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
        StopHover();

        OnPickedUp?.Invoke();
    }

    public virtual void Drop()
    {
        //réactive tout

        transform.parent = null;
        isInteractable = true;
        
        OnDropped?.Invoke();
    }
}
