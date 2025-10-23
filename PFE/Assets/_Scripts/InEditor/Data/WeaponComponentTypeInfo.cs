using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponComponentInfo", menuName = "WeaponComponentInfo")]
public class WeaponComponentTypeInfo : ScriptableObject
{
    [field : SerializeField]
    public string Name { get; private set; }

    [field : SerializeField]
    public string Description { get; private set; }

    [field : SerializeField]
    public Mesh Mesh { get; private set; }

    [field : SerializeField]
    public Sprite Sprite { get; private set; }
}
