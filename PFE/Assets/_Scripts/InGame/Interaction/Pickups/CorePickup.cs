using UnityEngine;

public class CorePickup : Pickup
{
    [SerializeField] public Core core;

    private void Awake()
    {
        TryGetComponent(out core);
    }

}
