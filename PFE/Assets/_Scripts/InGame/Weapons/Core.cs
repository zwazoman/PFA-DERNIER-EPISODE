using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
using UnityEngine.Events;

[RequireComponent(typeof(CoreEventCenter))]
public class Core : MonoBehaviour
{
    [HideInInspector] protected PlayerWeaponHandler weaponHandler;

    [Header("Public References")]
    [SerializeField] public CorePickup pickup;
    [SerializeField] public CoreEventCenter eventCenter;
    [SerializeField] public CoreTypeInfo coreData;

    public virtual void Equip(PlayerWeaponHandler newWeaponHandler)
    {
        weaponHandler = newWeaponHandler;
    }

    public virtual void UnEquip()
    {
        weaponHandler = null;
        pickup.Drop();
    }

    public virtual void StartShootTrigger() { }

    public virtual void StopShootTrigger() { }

    public virtual void ReloadTrigger() { }
}
