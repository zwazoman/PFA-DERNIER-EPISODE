using UnityEngine;

public class Interactable : MonoBehaviour
{
    [HideInInspector] public bool isInteractable = true;

    public virtual void Interact(PlayerInteraction interaction)
    {
        if (!isInteractable)
            return;
    }

    public virtual void StartHover()
    {
        if (!isInteractable)
            return;

        print(gameObject.name + " is hovered");
    }

    public virtual void StopHover()
    {
        print(gameObject.name + " is not hovered");
    }

    //gérer feedback
}
