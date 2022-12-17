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
    //[SerializeField] private float _delay;
    //[SerializeField] private float _transitionRange;
    //[SerializeField] private float _rangeSpread;

    private NavMeshAgent _navMeshAgent;
    //private float _lastAttackTime;
    private Player _player;
    public float Health=>_health;
    //public int Damage => _damage;

    public event UnityAction<Zombie> Dying;

    private void Start()
    {
        //_transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //_player = FindObjectOfType<Player>();
    }

    private void Update()
    {

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
        _zombieMovement.ChangeState(false);
        _zombieVoice.VoiceOff();
        Dying?.Invoke(this);
    }

    public void Attack(Player target)
    {
        target.ApplyDamage(_damage);
    }
}
