using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact()
    {
        base.Interact();
        
        OnPickup();
    }

    public virtual void OnPickup()
    {
        //désactive gravité collisions etc

        isInteractable = false;
        StopHover();
    }

    public virtual void OnDrop()
    {
        //réactive tout

        transform.parent = null;

        isInteractable = true;
    }
}
