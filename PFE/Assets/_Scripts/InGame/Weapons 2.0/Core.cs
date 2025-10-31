using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

public class Core : MonoBehaviour
{
    #region Events mais faut en faire des objets là
    public event Action OnShoot;
    public event Action OnStartShooting;
    public event Action OnStopShooting;
    public event Action OnDelay;

    #endregion

    [Header("References")]
    [SerializeField] Transform _shootSocket;
    WeaponHandler _handler;

    [Header("Shooting Parameters")]
    [SerializeField] protected float rateOfFire;
    [SerializeField] protected float fireDelay;
    [SerializeField] protected GameObject projectilePrefab;

    [Header("Magazine Parameters")]
    [SerializeField] protected int maxAmmoCount;
    [SerializeField] protected float reloadTimeTest = 1f;

    //Shooting handle
    protected bool isShooting = false;
    protected bool canShoot = true;

    //Magazine handle
    protected int currentAmmoCount;

    public void Activate()
    {
        transform.parent.TryGetComponent<WeaponHandler>(out _handler);

        _handler.OnStartShootingLeft += StartShooting;
        _handler.OnStopShootingLeft += StopShooting;
    }

    public void Deactivate()
    {
        _handler.OnStartShootingLeft -= StartShooting;
        _handler.OnStopShootingLeft -= StopShooting;
    }

    public virtual async void StartShooting()
    {
        OnStartShooting?.Invoke();

        isShooting = true;
        while (isShooting)
        {
            if (!canShoot)
            {
                await UniTask.Yield();
                continue;
            }

            if (currentAmmoCount == 0)
            {
                print("PLUS DE BALLES");
                StopShooting();
                Reload();
            }

            Shoot();
            await HandleDelay(fireDelay);
        }
    }

    protected virtual void Shoot()
    {
        OnShoot?.Invoke();

        Instantiate(projectilePrefab, _shootSocket.transform.position, _shootSocket.transform.rotation);
        currentAmmoCount--;
    }

    public virtual void StopShooting()
    {
        OnStopShooting?.Invoke();

        isShooting = false;
    }

    protected virtual async UniTask HandleDelay(float delay)
    {
        OnDelay?.Invoke();

        canShoot = false;
        await UniTask.WaitForSeconds(delay);
        canShoot = true;
    }

    protected async virtual void Reload()
    {
        canShoot = false;
        await HandleDelay(reloadTimeTest);

        currentAmmoCount = maxAmmoCount;

        canShoot = true;
    }
}
