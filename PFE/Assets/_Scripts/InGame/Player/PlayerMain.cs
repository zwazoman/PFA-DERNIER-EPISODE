using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [Header("Objects")]
    [field : SerializeField] 
    public Camera playerCamera { get; private set; }

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
    }
}
