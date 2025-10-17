using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
/// <summary>
/// reçoit les events liés aux armes et les lies aux WeaponComponents attachés
/// </summary>
public class WeaponCore : MonoBehaviour
{
    #region events
    [HideInInspector] public UnityEvent OnShoot;
    [HideInInspector] public UnityEvent OnAim;
    [HideInInspector] public UnityEvent OnReload;
    [HideInInspector] public UnityEvent OnAlt;
    #endregion

    [HideInInspector] public List<WeaponComponent> components = new();

    public void AddWeaponComponent(GameObject componentPrefab)
    {
        Instantiate(componentPrefab, transform);

        WeaponComponent newComponent = componentPrefab.GetComponent<WeaponComponent>();
        newComponent.Activate();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            OnReload.Invoke();
    }
}
