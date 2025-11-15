using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _prefab;

    [Header("Parameters")]
    [SerializeField] int _poolSize = 10;

    Queue<PoolObject> _pool = new();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject newObject = Instantiate(_prefab, transform);
            PoolObject poolObject = newObject.AddComponent<PoolObject>();
            poolObject.pool = this;

            _pool.Enqueue(poolObject);

            newObject.SetActive(false);
        }
    }

    public PoolObject PullFromPool(Vector3 position, Quaternion rotation)
    {
        PoolObject poolObject = _pool.Dequeue();
        poolObject.transform.parent = null;
        poolObject.transform.position = position;
        poolObject.transform.rotation = rotation;

        return poolObject;
    }

    public PoolObject PullFromPool(Transform parent)
    {
        PoolObject poolObject = PullFromPool(parent.position, parent.rotation);
        poolObject.transform.parent = parent;

        return poolObject;
    }

    public void PushToPool(PoolObject poolObject)
    {
        poolObject.transform.parent = transform;
        poolObject.transform.position = transform.position;
        poolObject.transform.rotation = transform.rotation;

        _pool.Enqueue(poolObject);
    }
}
