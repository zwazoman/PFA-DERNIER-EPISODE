using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
/// <summary>
/// reçoit les events liés aux armes et les lies aux WeaponComponents attachés
/// </summary>
public class WeaponCore : MonoBehaviour
{
    #region events a gérer avec input system de pref
    public event Action OnStartShootingLeft;
    public event Action OnStopShootingLeft;

    public event Action OnStartShootingRight;
    public event Action OnStopShootingRight;

    public event Action OnReload;

    public event Action OnAlt;
    #endregion

    #region Events

    public event Action<WeaponComponent> OnNewComponent;

    #endregion


    [HideInInspector] public List<WeaponComponent> components = new();

    private void Start()
    {
        CheckForComponents();
    }

    public void TryAddNewWeaponComponent(GameObject componentPrefab)
    {
        Instantiate(componentPrefab, transform);

        WeaponComponent newComponent = componentPrefab.GetComponent<WeaponComponent>();
        ActivateComponent(newComponent);
    }

    void CheckForComponents()
    {
        foreach(WeaponComponent weaponComp in GetComponentsInChildren<WeaponComponent>())
        {
            if (!components.Contains(weaponComp))
            {
                ActivateComponent(weaponComp);
            }
        }
    }

    void ActivateComponent(WeaponComponent newComponent)
    {
        newComponent.Activate();
        components.Add(newComponent);
        OnNewComponent?.Invoke(newComponent);
    }

    public T AccessComponent<T>() where T : WeaponComponent
    {
        return GetComponentInChildren<T>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            OnStartShootingLeft?.Invoke();
        if(Input.GetKeyUp(KeyCode.Mouse0))
            OnStopShootingLeft?.Invoke();

        if(Input.GetKeyDown(KeyCode.Mouse1))
            OnStartShootingRight?.Invoke();
        if( Input.GetKeyUp(KeyCode.Mouse1))
            OnStopShootingRight?.Invoke();

        if(Input.GetKeyDown(KeyCode.R))
            OnReload.Invoke();
    }
}
