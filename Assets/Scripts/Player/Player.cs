using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;

    private int _currentHealth;
    private int _score = 0;
    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction Died;
    public event UnityAction<int> ChangeScore;

    private void Start()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            _animator.SetBool("Die", true);
            Die();
        }
    }

    public void ChangeHealth(int health)
    {
        _currentHealth += health;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth > 100)
        {
            _currentHealth = 100;
        }
    }

    public void Die()
    {
        Died?.Invoke();
    }

    public void AddScore()
    {
        _score++;
        ChangeScore?.Invoke(_score);
    }
}
