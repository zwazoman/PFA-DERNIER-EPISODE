using UnityEngine;

[RequireComponent(typeof(WC))]
public class WCPickup : Pickup<WC>
{
    protected override void Awake()
    {
        base.Awake();

        TryGetComponent(out linkedObject);
    }

    protected override async void TryPickup(PlayerInteraction interaction)
    {
        bool WcLinked = await interaction.main.playerWeaponHandler.LinkWC(linkedObject);

        if(WcLinked)
        {
            base.TryPickup(interaction);
        }
    }
}
