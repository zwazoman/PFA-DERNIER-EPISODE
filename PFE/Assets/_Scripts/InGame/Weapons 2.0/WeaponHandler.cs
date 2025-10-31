using System;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    #region Input Events
    public event Action OnStartShootingLeft;
    public event Action OnStopShootingLeft;

    public event Action OnStartShootingRight;
    public event Action OnStopShootingRight;

    public event Action OnReload;

    #endregion

    [Header("References")]
    public Core LeftWeaponCore;
    public Core RightWeaponCore;

    [Header("Parameters")]
    [SerializeField] float _reloadHoldWindow = .5f;

    float _reloadTimer = 0f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            OnStartShootingLeft?.Invoke();
        if(Input.GetKeyUp(KeyCode.Mouse0))
            OnStopShootingLeft.Invoke();

        if(Input.GetKeyDown(KeyCode.Mouse1))
            OnStartShootingRight?.Invoke();
        if( Input.GetKeyUp(KeyCode.Mouse1))
            OnStopShootingRight?.Invoke();

        if (Input.GetKey(KeyCode.R))
            _reloadTimer += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.R))
            Reload(_reloadTimer);

    }

    public void AddCore(Core newCore)
    {

    }

    public void RemoveCore(Core coreToRemove)
    {

    }

    void Reload(float timer)
    {
        OnReload?.Invoke();

        if (timer < _reloadHoldWindow)
        {
            print("fastReload");
        }
        else
            print("chooseReload");

        _reloadTimer = 0;
    }


}
