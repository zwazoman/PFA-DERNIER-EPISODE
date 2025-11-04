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

        if (!Physics.Raycast(main.playerCamera.transform.position, main.playerCamera.transform.forward, out hit, _interactReach))
            return;

        print(hit.collider.gameObject.name);

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
                _currentInteractable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(main.playerCamera.transform.position, main.playerCamera.transform.forward * _interactReach);
    }
}
