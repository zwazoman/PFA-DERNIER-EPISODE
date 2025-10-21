using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
/// <summary>
/// re�oit les events li�s aux armes et les lies aux WeaponComponents attach�s
/// </summary>
public class WeaponCore : MonoBehaviour
{
    #region events a g�rer avec input system de pref
    [HideInInspector] public UnityEvent OnStartShooting;
    [HideInInspector] public UnityEvent OnStopShooting;
    [HideInInspector] public UnityEvent OnAim;
    [HideInInspector] public UnityEvent OnReload;
    [HideInInspector] public UnityEvent OnAlt;
    #endregion

    [HideInInspector] public List<WeaponComponent> components = new();

    public void TryAddNewWeaponComponent(GameObject componentPrefab)
    {
        Instantiate(componentPrefab, transform);

        WeaponComponent newComponent = componentPrefab.GetComponent<WeaponComponent>();
        newComponent.Activate();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            OnStartShooting?.Invoke();
        if(Input.GetKeyUp(KeyCode.Mouse0))
            OnStopShooting?.Invoke();

        if(Input.GetKeyDown(KeyCode.R))
            OnReload.Invoke();
    }
}
