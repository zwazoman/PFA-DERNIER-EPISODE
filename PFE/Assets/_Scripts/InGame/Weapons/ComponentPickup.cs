using System;
using UnityEngine;

[Flags]
public enum EnormeChiasseCoulante
{
    Diarhée,
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
