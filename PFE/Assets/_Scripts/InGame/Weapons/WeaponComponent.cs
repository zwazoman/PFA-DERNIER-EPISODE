using UnityEngine;

/// <summary>
/// components s'attachant a une arme et lui rajoutant des caractéristiques
/// </summary>
public class WeaponComponent : MonoBehaviour
{
    protected WeaponCore core;

    private void Awake()
    {
        TryGetComponent(out core);
    }

    protected virtual void LinkToWeaponAction() { }
    
    public virtual void Activate() { }
    public virtual void Deactivate() { }
}
