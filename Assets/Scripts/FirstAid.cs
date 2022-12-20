using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FirstAid : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private int _healthPoint = 30;
    private float _destroyFirstAid = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            player.ChangeHealth(_healthPoint);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(gameObject, _destroyFirstAid);
        }
    }
}
