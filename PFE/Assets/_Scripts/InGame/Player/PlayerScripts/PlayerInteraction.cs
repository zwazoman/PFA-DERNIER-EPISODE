using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : PlayerScript
{
    [Header("Parameters")]
    [SerializeField] float _interactReach = 5;

    Interactable _currentInteractable;
    Pickup _currentPickup;

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(main.playerCamera.transform.position, main.playerCamera.transform.forward, out hit, _interactReach);

        Interactable interactable;
        if (hit.collider.gameObject.TryGetComponent(out interactable))
        {
            if (interactable == _currentInteractable)
                return;

            _currentInteractable = interactable;
            _currentInteractable.StartHover();
        }
        else
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.StopHover();
                _currentInteractable = null;
            }
        }
    }

    public void Drop()
    {

    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_currentInteractable != null)
            {
                if(_currentInteractable is Pickup)
                {
                    Pickup pickup = _currentInteractable as Pickup;
                    _currentPickup = pickup;
                    pickup.OnPickup(this);
                }
                else
                    _currentInteractable.Interact();
            }
        }
    }
}
