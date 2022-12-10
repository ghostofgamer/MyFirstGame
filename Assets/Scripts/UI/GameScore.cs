using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreDisplay;

    private void OnEnable()
    {
        _player.ChangeScore += OnScoreAdded;
    }

    private void OnDisable()
    {
        _player.ChangeScore -= OnScoreAdded;
    }

    private void OnScoreAdded(int score)
    {
        _scoreDisplay.text = score.ToString();
    }
}
