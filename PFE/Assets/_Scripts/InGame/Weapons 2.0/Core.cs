using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(CoreEventCenter))]
public class Core : MonoBehaviour
{
    #region Events mais faut en faire des objets là
    public event Action OnShoot;
    public event Action OnStartShooting;
    public event Action OnStopShooting;
    public event Action OnDelay;
    #endregion

    [Header("Public References")]
    [SerializeField] public CorePickup pickup;
    [SerializeField] public CoreEventCenter eventCenter;
    [SerializeField] public CoreTypeInfo coreData;

    [Header("Private References")]
    [SerializeField] Transform _shootSocket;
    
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

    private void Awake()
    {
        TryGetComponent(out eventCenter);
        TryGetComponent(out pickup);
    }

    public virtual void Activate() { }

    public virtual void Deactivate() { }

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

    public virtual void StopShooting()
    {
        OnStopShooting?.Invoke();

        isShooting = false;
    }

    public async virtual void Reload()
    {
        canShoot = false;
        await HandleDelay(reloadTimeTest);

        currentAmmoCount = maxAmmoCount;

        canShoot = true;
    }

    protected virtual void Shoot()
    {
        OnShoot?.Invoke();

        Instantiate(projectilePrefab, _shootSocket.transform.position, _shootSocket.transform.rotation);
        currentAmmoCount--;
    }

    protected virtual async UniTask HandleDelay(float delay)
    {
        OnDelay?.Invoke();

        canShoot = false;
        await UniTask.WaitForSeconds(delay);
        canShoot = true;
    }
}
