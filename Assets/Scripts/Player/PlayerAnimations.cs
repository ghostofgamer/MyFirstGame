using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Run = "Run";
    private const string Shoot = "Shoot";
    private const string Back = "Back";
    private const string Die = "Die";

    public void Running(bool change)
    {
        _animator.SetBool(Run, change);
    }

    public void RunBack(bool change)
    {
        _animator.SetBool(Back, change);
    }

    public void Shooting(bool change)
    {
        _animator.SetBool(Shoot, change);
    }

    public void DiePlayer(bool change)
    {
        _animator.SetBool(Die, change);
    }
}
