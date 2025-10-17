using System;
using UnityEngine;

[Flags]
public enum EnormeChiasseCoulante
{
    Diarh�e,
    Collique,
    Courante,
    Coulante,
    Tourista,
}

public class ComponentPickup : MonoBehaviour
{
    [SerializeField] GameObject _componentPrefab;

    public GameObject Pickup()
    {
        //juice
        Destroy(gameObject);

        return _componentPrefab;
    }
}
