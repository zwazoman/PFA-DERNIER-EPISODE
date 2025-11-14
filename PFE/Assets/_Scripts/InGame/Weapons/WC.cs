using UnityEngine;

public class WC : MonoBehaviour
{
    [Header("Parameteres")]

    [SerializeField] int cost;
    [SerializeField] int rarity;
    [SerializeField] WCTypes _types;

    public virtual void Activate() { }
    public virtual void Deactivate() { }

    public void LinkToCore()
    {

    }
}
