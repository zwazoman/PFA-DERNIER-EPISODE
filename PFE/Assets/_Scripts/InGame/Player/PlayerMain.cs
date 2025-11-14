using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMain : MonoBehaviour
{
    [Header("Objects")]
    [field : SerializeField] 
    public Camera playerCamera { get; private set; }

    [field : SerializeField]
    public PlayerInput playerInput { get; private set; }

    [Header("Scripts")]
    [field : SerializeField]
    public PlayerMovement playerMovement { get; private set; }

    [field : SerializeField]
    public PlayerWeaponHandler playerWeaponHandler { get; private set; }

    [field: SerializeField]
    public PlayerInteraction playerInteraction { get; private set; }

    [field : SerializeField]
    public PlayerUiMain uiMain { get; private set; }

    private void Start()
    {
        playerMovement.main = this;
        playerWeaponHandler.main = this;
        playerInteraction.main = this;
        uiMain.main = this;

        playerInput.currentActionMap.Disable();

        //SwapActionMapToUI();
    }

    public bool CheckActionmap(InputActionMap actionMap)
    {
        if (actionMap == playerInput.currentActionMap)
            return true;
        return false;
    }

    public void SwapActionMapToUI()
    {
        Cursor.lockState = CursorLockMode.Confined;

        playerInput.SwitchCurrentActionMap("UI");
    }

    public void SwapActionMapToPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerInput.SwitchCurrentActionMap("Player");
    }
}
