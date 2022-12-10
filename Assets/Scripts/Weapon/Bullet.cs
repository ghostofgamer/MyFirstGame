using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    private float _timeDestroyBullet;

    private void Update()
    {
        _timeDestroyBullet += Time.deltaTime;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        if (_timeDestroyBullet > 3f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Zombie zombie))
        {
            zombie.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
