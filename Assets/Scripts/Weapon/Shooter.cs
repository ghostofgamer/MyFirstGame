using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _crossHair;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private SoundShooter _soundShooter;
    [SerializeField] private InputMouse _inputMouse;

    private Coroutine _coroutine;
    private int damage = 5;
    private float _timeWait = 0.3f;

    private RaycastHit GetRaycastHit()
    {
        var ray = _camera.ScreenPointToRay(_crossHair.transform.position);
        Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity);
        return hit;
    }

    private void OnEnable()
    {
        _inputMouse.MouseDown += OnPressed;
        _inputMouse.MouseUp += OnUnPressed;
    }

    private void OnDisable()
    {
        _inputMouse.MouseDown -= OnPressed;
        _inputMouse.MouseUp -= OnUnPressed;
    }

    private void OnPressed()
    {
        _coroutine = StartCoroutine(FireWeapon());
        _playerAnimations.Shooting(true);
    }

    private void OnUnPressed()
    {
        StopCoroutine(_coroutine);
        _playerAnimations.Shooting(false);
    }

    private IEnumerator FireWeapon()
    {
        var wait = new WaitForSeconds(_timeWait);

        while (true)
        {
            _soundShooter.AudioShoot();

            if (GetRaycastHit().collider.TryGetComponent(out Zombie zombie))
            {
                zombie.TakeDamage(damage);
                print("убийство");
            }

            yield return wait;
        }
    }
}
