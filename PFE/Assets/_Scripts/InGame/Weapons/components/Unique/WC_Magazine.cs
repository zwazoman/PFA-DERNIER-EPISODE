using System;
using UnityEngine;

public class WC_Magazine : WeaponComponent
{
    #region Events
    public event Action OnConsumeAmmo;
    public event Action OnReload;
    public event Action OnEmpty;

    #endregion

    [SerializeField] int _ammoCapacity;
    [SerializeField] string _reloadAnimationTriggerName;

    int _currentAmmo;

    public override void Activate()
    {
        _currentAmmo = _ammoCapacity;
        core.OnReload += Reload;
        //core.OnShoot.AddListener(ConsumeAmmo);
    }

    void Reload()
    {
        print("AAAAAHHHHH");
        _currentAmmo = _ammoCapacity;
    }

    void ConsumeAmmo()
    {
        _currentAmmo--;

        if(_currentAmmo <= 0)
        {
            OnEmpty?.Invoke();
        }
    }
    //faut gérer le UI et les feedbacks aussi
}
