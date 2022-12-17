using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimations : MonoBehaviour
{
    private const string Died = "Die";
    private const string ToAttack = "Attack";
    private const string Run = "Z_Run";

    [SerializeField] private Animator _animator;

    public void ToAttacking()
    {
        _animator.Play(ToAttack);
    }

    public void Running()
    {
        _animator.Play(Run);
    }

    public void DieZombie(bool flag)
    {
        _animator.SetBool(Died, flag);
    }
}
