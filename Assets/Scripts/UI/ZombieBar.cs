using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBar : Bar
{
    [SerializeField] private Spawner _spawn;

    private void OnEnable()
    {
        _spawn.EnemyCountChanged += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawn.EnemyCountChanged -= OnValueChanged;
    }
}
