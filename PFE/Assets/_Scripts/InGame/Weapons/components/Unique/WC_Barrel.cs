using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class WC_Barrel : WeaponComponent
{
    #region Events
    public event Action OnShoot;
    public event Action OnStartShooting;
    public event Action OnStopShooting;
    public event Action OnDelay;

    #endregion

    [SerializeField] protected float RateOfFire;
    [SerializeField] protected float FireDelay;
    [SerializeField] protected GameObject ProjectilePrefab;

    protected bool IsShooting = false;
    protected bool CanShoot = true;

    public override void Activate()
    {
        base.Activate();

        core.OnStartShootingLeft += StartShooting;
        core.OnStopShootingLeft += StopShooting;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        core.OnStartShootingLeft -= StartShooting;
        core.OnStopShootingLeft -= StopShooting;
    }

    public virtual async void StartShooting()
    {
        OnStartShooting?.Invoke();

        IsShooting = true;
        while (IsShooting)
        {
            if (!CanShoot)
            {
                await UniTask.Yield();
                continue;
            }
                
            Shoot();
            await HandleDelay();
        }
    }

    public virtual void StopShooting()
    {
        OnStopShooting?.Invoke();

        IsShooting = false;
    }

    protected virtual void Shoot()
    {
        OnShoot?.Invoke();

        Instantiate(ProjectilePrefab, transform.position, core.gameObject.transform.rotation);
    }

    protected virtual async UniTask HandleDelay()
    {
        OnDelay?.Invoke();

        CanShoot = false;
        await UniTask.WaitForSeconds(FireDelay);
        CanShoot = true;
    }
}
