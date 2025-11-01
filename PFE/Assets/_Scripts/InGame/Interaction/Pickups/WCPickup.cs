using UnityEngine;

public class WCPickup : MonoBehaviour
{
    [SerializeField] public WC weaponComponent;

    private void Awake()
    {
        TryGetComponent(out weaponComponent);
    }
}
