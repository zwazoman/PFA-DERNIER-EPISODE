using UnityEngine;

public class WC_Magazine : UniqueWeaponComponent
{
    [SerializeField] int _ammoCapacity;
    [SerializeField] string _reloadAnimationTriggerName;

    int _currentAmmo;

    public override void Activate()
    {
        _currentAmmo = _ammoCapacity;
        core.OnReload.AddListener(Reload);
        core.OnShoot.AddListener(ConsumeAmmo);
    }

    void Reload()
    {
        print("AAAAAHHHHH");
        _currentAmmo = _ammoCapacity;
    }

    void ConsumeAmmo()
    {
        _currentAmmo--;
    }
    

    //faut gérer le UI et les feedbacks aussi
}
