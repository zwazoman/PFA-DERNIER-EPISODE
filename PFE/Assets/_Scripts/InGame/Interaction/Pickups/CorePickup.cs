using UnityEngine;

[RequireComponent(typeof(Core))]
public class CorePickup : Pickup
{
    [SerializeField] public Core core;

    protected override void Awake()
    {
        base.Awake();

        TryGetComponent(out core);
    }

    protected override void OnPickup(PlayerInteraction interaction)
    {
        bool coreLinked = interaction.main.playerWeaponHandler.LinkCore(core);

        if (coreLinked)
        {
            base.OnPickup(interaction);
        }
    }
}
