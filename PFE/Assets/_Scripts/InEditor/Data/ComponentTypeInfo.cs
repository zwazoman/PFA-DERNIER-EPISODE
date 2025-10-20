using UnityEngine;

[CreateAssetMenu(fileName = "NewComponentInfo", menuName = "ComponentInfo")]
public class ComponentTypeInfo : ScriptableObject
{
    [field : SerializeField]
    public string Name { get; private set; }

    [field : SerializeField]
    public string Description { get; private set; }
}
