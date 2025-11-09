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
}
