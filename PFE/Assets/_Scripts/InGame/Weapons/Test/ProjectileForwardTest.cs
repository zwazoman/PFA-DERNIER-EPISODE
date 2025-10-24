using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    [SerializeField] float _speed = 10;
    [SerializeField] float _lifeTime = 3;

    float _timer = 0f;

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        _timer += Time.deltaTime;

        if (_timer >= _lifeTime)
            Destroy(gameObject);

    }
}
