
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCoreData", menuName = "Weapon/CoreData")]
public class CoreTypeInfo : ScriptableObject
{
    [field: SerializeField]
    public string coreName { get; private set; }

    [field : SerializeField]
    public Sprite sprite { get; private set; }

    [SerializedDictionary("Name", "CoreEvent")]
    public SerializedDictionary<string, CoreEvent> coreEvents;
}
