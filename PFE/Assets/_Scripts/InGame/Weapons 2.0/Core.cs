using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    #region Events mais faut en faire des objets là
    public event Action OnShoot;
    public event Action OnStartShooting;
    public event Action OnStopShooting;
    public event Action OnDelay;

    public CoreEvent ShootEvent;

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

    public virtual void Activate()
    {

    }

    public virtual void Deactivate()
    {

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

[Serializable]
public struct CoreEvent
{
    public UnityEvent Event;
    public string Name;
    public int Slots;
}