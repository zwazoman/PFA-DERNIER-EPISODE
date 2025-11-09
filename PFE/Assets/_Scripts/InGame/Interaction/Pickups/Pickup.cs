using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact(PlayerInteraction interaction)
    {
        base.Interact(interaction);

        OnPickup(interaction);
    }

    protected virtual void OnPickup(PlayerInteraction interaction)
    {
        //désactive gravité collisions etc

        print("picked up");
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
