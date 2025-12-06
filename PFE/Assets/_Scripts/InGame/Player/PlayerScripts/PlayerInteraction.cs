using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : PlayerScript
{
    [Header("Parameters")]
    [SerializeField] float _interactReach = 5;
    [SerializeField] LayerMask _interactMask;

    Interactable _currentInteractable;

    private void Update()
    {
        RaycastHit hit;

        if (!Physics.Raycast(main.playerCamera.transform.position, main.playerCamera.transform.forward, out hit, _interactReach, _interactMask))
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.StopHover();
                _currentInteractable = null;
            }
            return;
        }

        Interactable interactable;
        if (hit.collider.gameObject.TryGetComponent(out interactable) && interactable.isInteractable)
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
            print("try interact");

            if(_currentInteractable != null)
            {
                print("interact");
                _currentInteractable.Interact(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(main.playerCamera.transform.position, main.playerCamera.transform.position + main.playerCamera.transform.forward * _interactReach);
    }
}
