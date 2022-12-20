using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private ZombieAnimations _zombieAnimations;
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;
    [SerializeField] private float _delay;

    private bool _isRun = true;
    private NavMeshAgent _navMeshAgent;
    private Player _player;
    private float _lastAttackTime;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_isRun)
        {
            _navMeshAgent.SetDestination(_player.transform.position);

            if (Vector3.Distance(transform.position, _player.transform.position) < _transitionRange)
            {
                _zombieAnimations.ToAttacking();

                if (_lastAttackTime <= 0)
                {
                    _zombie.Attack(_player);
                    _lastAttackTime = _delay;
                }
                _lastAttackTime -= Time.deltaTime;
            }

            if (_navMeshAgent.remainingDistance > _transitionRange)
            {
                _zombieAnimations.Running();
            }
        }
    }

    public void Dying(bool flag)
    {
        _isRun = flag;
    }
}
