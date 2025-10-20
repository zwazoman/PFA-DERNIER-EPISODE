using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] WeaponCore _core;

    [SerializeField] ComponentPickup pickupTest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Pickup();
    }

    public void Pickup()
    {
        _core.TryAddNewWeaponComponent(pickupTest.Pickup());
    }
}
