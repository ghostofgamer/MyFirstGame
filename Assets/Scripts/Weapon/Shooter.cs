using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _crossHair;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private SoundShooter _soundShooter;

    private Coroutine _coroutine;
    private int damage = 5;
    private float _timeWait = 0.3f;

    private RaycastHit GetRaycastHit()
    {
        var ray = _camera.ScreenPointToRay(_crossHair.transform.position);
        Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity);
        return hit;
    }

    //public void Shoot(bool flag)
    //{
    //    if (flag == true)
    //    {
    //        _timeWait -= Time.deltaTime;
    //        _playerAnimations.Shooting(true);

    //        if (_timeWait < 0f)
    //        {
    //            _timeWait = 0.3f;
    //            _soundShooter.AudioShoot();

    //            if (GetRaycastHit().collider.TryGetComponent(out Zombie zombie))
    //            {
    //                zombie.TakeDamage(damage);
    //            }
    //        }
    //    }
    //}

    public void StartCorutineShoot()
    {
        if (_coroutine != null)
        {
            StopCoroutine(FireWeapon());
        }
        _coroutine = StartCoroutine(FireWeapon());
        _playerAnimations.Shooting(true);
        _soundShooter.AudioShoot();
    }

    public void StopShoot()
    {
        StopCoroutine(FireWeapon());
        _playerAnimations.Shooting(false);
    }

    private IEnumerator FireWeapon()
    {
        var WaitForSeconds = new WaitForSeconds(_timeWait);

        if (GetRaycastHit().collider.TryGetComponent(out Zombie zombie))
        {
            zombie.TakeDamage(damage);
            print("убийство");
        }
        yield return WaitForSeconds;
    }
}
