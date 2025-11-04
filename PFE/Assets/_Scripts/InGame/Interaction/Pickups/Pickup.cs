using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact(PlayerInteraction interaction)
    {
        base.Interact(interaction);

        OnPickup(interaction);
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
