using UnityEngine;


public class CorePickup : Pickup
{
    [SerializeField] public Core core;

    protected override void Awake()
    {
        base.Awake();

        TryGetComponent(out core);
    }

    protected override async void TryPickup(PlayerInteraction interaction)
    {
        bool coreLinked = await interaction.main.playerWeaponHandler.LinkCore(core);

        if (coreLinked)
        {
            base.TryPickup(interaction);
        }
    }

    public override void OnGainedOwnership()
    {
        base.OnGainedOwnership();

        print("GAINED OWNERSHIP : " + OwnerClientId);
    }

    public override void OnLostOwnership()
    {
        base.OnLostOwnership();

        print("LOST OWNERSHIP");
    }
}
