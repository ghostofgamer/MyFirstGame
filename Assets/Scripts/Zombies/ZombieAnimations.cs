using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string Died = "Die";
    private const string ToAttack = "Attack";
    private const string Run = "Z_Run";

    public void ToAttacking()
    {
        _animator.Play(ToAttack);
    }

    public void Running()
    {
        _animator.Play(Run);
    }

    public void DieZombie(bool change)
    {
        _animator.SetBool(Died, change);
    }
}
