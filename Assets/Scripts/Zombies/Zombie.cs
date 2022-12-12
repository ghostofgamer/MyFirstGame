using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private NavMeshAgent _navMeshAgent;
    private float _lastAttackTime;
    private Player _player;
    private const string Died = "Die";
    private const string ToAttack = "Attack";
    private const string Run = "Z_Run";

    public event UnityAction<Zombie> Dying;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_health > 0)
        {
            _navMeshAgent.SetDestination(_player.transform.position);

            if (Vector3.Distance(transform.position, _player.transform.position) < _transitionRange)
            {
                _animator.Play(ToAttack);

                if (_lastAttackTime <= 0)
                {
                    Attack(_player);
                    _lastAttackTime = _delay;
                }
                _lastAttackTime -= Time.deltaTime;
            }

            if (_navMeshAgent.remainingDistance > _transitionRange)
            {
                _animator.Play(Run);
            }
        }
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
            _animator.SetBool(Died, true);
            _audioSource.Stop();
            Dying?.Invoke(this);
        }
    }

    private void Die()
    {
        _navMeshAgent.Stop();
    }

    private void Attack(Player target)
    {
        target.ApplyDamage(_damage);
    }
}
