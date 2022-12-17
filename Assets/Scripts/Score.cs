using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private int _score = 0;

    public event UnityAction<int> ChangeScore;

    public void AddScore()
    {
        _score++;
        ChangeScore?.Invoke(_score);
    }
}
