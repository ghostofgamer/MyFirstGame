using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private int _health;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction Died;

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
            _playerAnimations.DiePlayer(true);
            Die();
        }
    }

    public void ChangeHealth(int health)
    {
        _currentHealth += health;
        HealthChanged?.Invoke(_currentHealth, _health);
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
