using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : MonoBehaviour
{
    [SerializeField] private ZombieMovement _zombieMovement;
    [SerializeField] private ZombieVoice _zombieVoice;
    [SerializeField] private ZombieAnimations _zombieAnimations;
    [SerializeField] private float _health;
    [SerializeField] private int _damage;

    private NavMeshAgent _navMeshAgent;
    private Player _player;

    public event UnityAction<Zombie> Dying;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Init(Player target)
    {
        _player = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _navMeshAgent.Stop();
        _zombieAnimations.DieZombie(true);
        _zombieMovement.Dying(false);
        _zombieVoice.VoiceOff();
        Dying?.Invoke(this);
    }

    public void Attack(Player target)
    {
        target.ApplyDamage(_damage);
    }
}
