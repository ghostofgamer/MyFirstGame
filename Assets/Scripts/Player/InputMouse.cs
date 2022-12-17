using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouse : MonoBehaviour
{
    [SerializeField] private InputCamera _inputCamera;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private int _sensivity = 3;
    [SerializeField] private float _rotate = 80f;

    private float _mouseY;
    private Vector2 _direction;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Shooting();
            _shooter.StartCorutineShoot();
        }
        else
        {
            _shooter.StopShoot();
            //_playerAnimations.Shooting(false);
        }
        _direction = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _mouseY -= _direction.y * _sensivity;
        _mouseY = Mathf.Clamp(_mouseY, -_rotate, _rotate);
        _inputCamera.SetDirectionX(_direction.x);
        _inputCamera.SetDirectionY(_mouseY);
        //_playerMovement.SetDirectionX(_direction.x);
        //_playerMovement.SetDirectionY(_mouseY);
    }
}
