using Cysharp.Threading.Tasks;
using UnityEngine;

public class ClassicCore : Core
{
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

    public override void Equip(PlayerWeaponHandler weaponHandler)
    {
        base.Equip(weaponHandler);
    }

    public override void UnEquip()
    {
        base.UnEquip();
    }

    public override void StartShootTrigger() => StartShooting();

    public override void StopShootTrigger() => StopShooting();

    public override void ReloadTrigger() => Reload();

    public virtual async void StartShooting()
    {
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
        Instantiate(projectilePrefab, _shootSocket.transform.position, _shootSocket.transform.rotation);
        currentAmmoCount--;
    }

    protected virtual async UniTask HandleDelay(float delay)
    {
        canShoot = false;
        await UniTask.WaitForSeconds(delay);
        canShoot = true;
    }
}
