using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class WC_Barrel : WeaponComponent
{
    #region events
    public event Action OnShoot;
    public event Action OnStartShooting;
    public event Action OnStopShooting;
    public event Action OnDelay;

    #endregion

    [SerializeField] protected float RateOfFire;
    [SerializeField] protected float FireDelay;
    [SerializeField] protected GameObject ProjectilePrefab;
    [SerializeField] protected float Range;

    protected bool IsShooting = false;

    public override void Activate()
    {
        base.Activate();

        core.OnStartShooting.AddListener(StartShooting);
        core.OnStopShooting.AddListener(StopShooting);
    }

    public override void Deactivate()
    {
        base.Deactivate();

        core.OnStartShooting.RemoveListener(StartShooting);
        core.OnStopShooting.RemoveListener(StopShooting);
    }

    public virtual async void StartShooting()
    {
        OnStartShooting?.Invoke();

        IsShooting = true;
        while (IsShooting)
        {
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
    }

    protected virtual async UniTask HandleDelay()
    {
        OnDelay?.Invoke();

        await UniTask.WaitForSeconds(FireDelay);
    }
}
