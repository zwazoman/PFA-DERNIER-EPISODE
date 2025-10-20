using UnityEngine;

public class WC_BouncingProjectile : WeaponComponent
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Transform _shootSocket;

    public override void Activate()
    {
        core.OnShoot.AddListener(Shoot);
    }

    public override void Deactivate()
    {
        core.OnShoot.RemoveListener(Shoot);
    }

    protected virtual void Shoot()
    {
        Instantiate(_projectilePrefab, _shootSocket.position, Quaternion.identity);
    }
}
