using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponComponentInfo", menuName = "Weapons/WeaponComponentInfo")]
public class WCTypeInfo : ScriptableObject
{
    [field : SerializeField]
    public string wcName { get; private set; }

    [field : SerializeField]
    public string description { get; private set; }

    [field : SerializeField]
    public Sprite sprite { get; private set; }

    [field: SerializeField]
    public WCTypes types { get; private set; }
}
