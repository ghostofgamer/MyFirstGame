using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string Run = "Run";
    private const string Shoot = "Shoot";
    private const string Back = "Back";
    private const string Die = "Die";
    private const string Move = "Move";
    private const string Strafe = "Strafe";

    [SerializeField] private Animator _animator;

    //public void Running(bool flag)
    //{
    //    _animator.SetBool(Run, flag);
    //}

    //public void RunBack(bool flag)
    //{
    //    _animator.SetBool(Back, flag);
    //}

    public void Shooting(bool flag)
    {
        _animator.SetBool(Shoot, flag);
    }

    public void DiePlayer(bool flag)
    {
        _animator.SetBool(Die, flag);
    }

    public void ToMove(float value)
    {
        _animator.SetFloat(Move, value);
    }

    public void ToStrafe(float value)
    {
        _animator.SetFloat(Strafe, value);
    }
}
