using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact()
    {
        base.Interact();
    }

    public virtual void OnPickup(PlayerInteraction interaction)
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
