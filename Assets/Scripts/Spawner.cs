using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;

    private Transform[] _points;
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterlastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
        _points = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points[i] = _spawnPoint.GetChild(i);
        }
        Spawners();
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }
            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Zombie enemy = Instantiate(_currentWave.Template[Random.Range(0, _currentWave.Template.Length)], _points[Random.Range(0, _points.Length)].position, Quaternion.identity).GetComponent<Zombie>();
        enemy.Init(_player);
        enemy.Dying += OnDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void OnDying(Zombie zombie)
    {
        zombie.Dying -= OnDying;
        _score.AddScore();
    }

    public void Spawners()
    {
        StartCoroutine(SpawnMobs());
    }

    private IEnumerator SpawnMobs()
    {
        for (int i = 0; i < _currentWave.Count; i++)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterlastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            yield return new WaitForSeconds(_currentWave.Delay);
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject[] Template;
    public float Delay;
    public int Count;
}
