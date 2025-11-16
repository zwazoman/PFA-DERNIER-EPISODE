using UnityEngine;

[RequireComponent(typeof(WC))]
public class WCPickup : Pickup
{
    [SerializeField] public WC weaponComponent;

    protected override void Awake()
    {
        base.Awake();

        TryGetComponent(out weaponComponent);
    }

    protected override async void TryPickup(PlayerInteraction interaction)
    {
        bool WcLinked = await interaction.main.playerWeaponHandler.LinkWC(weaponComponent);

        if(WcLinked)
        {
            base.TryPickup(interaction);
        }
    }
}
