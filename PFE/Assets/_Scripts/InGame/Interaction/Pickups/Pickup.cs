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
        //d�sactive gravit� collisions etc

        isInteractable = false;
        StopHover();
    }

    public virtual void OnDrop()
    {
        //r�active tout

        transform.parent = null;

        isInteractable = true;
    }
}
