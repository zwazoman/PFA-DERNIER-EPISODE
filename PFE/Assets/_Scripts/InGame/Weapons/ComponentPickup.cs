using UnityEngine;

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
