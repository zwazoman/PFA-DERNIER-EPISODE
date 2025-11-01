using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;

    public virtual void Interact()
    {
        if (!isInteractable)
            return;
    }

    public virtual void StartHover()
    {
        if (!isInteractable)
            return;
    }

    public virtual void StopHover()
    {

    }

    //gérer feedback
}
