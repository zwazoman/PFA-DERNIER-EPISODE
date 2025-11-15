using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public Pool pool;

    IPoolable _poolable;

    private void Awake()
    {
        if (!TryGetComponent(out _poolable))
            Debug.LogError("No poolable on the pool prefab");
    }

    public void OnPulledFromPool()
    {
        _poolable.OnPulledFromPool();
    }

    public void PushToPool()
    {
        _poolable.OnPushedToPool();

        pool.PushToPool(this);
    }
}
