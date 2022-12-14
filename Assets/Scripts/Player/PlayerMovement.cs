using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SoundShooter _soundShooter;
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _camera;

    private float _timeWait = 0.3f;
    private float _rotateSpeed = 180f;
    private float _mouseY;
    private float _rotate = 80f;
    private int _sensivity = 3;

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float horizontal = Input.GetAxis("Horizontal");
        _mouseY -= Input.GetAxis("Mouse Y") * _sensivity;
        _mouseY = Mathf.Clamp(_mouseY, -_rotate, _rotate);
        Vector3 offset = Vector3.zero;
        offset += HorizontalMovement(horizontal, offset);
        offset += VerticalMovement(vertical, offset, horizontal);
        MouseY(_mouseY);
        MouseX(mouseX);

        if (Input.GetMouseButton(0))
        {
            Shooting();
        }
        else
        {
            _playerAnimations.Shooting(false);
        }
        offset += Physics.gravity * Time.deltaTime;
        _controller.Move(offset);
    }

    private Vector3 HorizontalMovement(float horizontal, Vector3 offset)
    {
        if (horizontal != 0)
        {
            offset += transform.right * horizontal * _speed * Time.deltaTime;
            _playerAnimations.Running(true);
        }
        else
        {
            _playerAnimations.Running(false);
        }
        return offset;
    }

    private Vector3 VerticalMovement(float vertical, Vector3 offset, float horizontal)
    {
        if (vertical > 0)
        {
            offset += transform.forward * vertical * _speed * Time.deltaTime;
            _playerAnimations.Running(true);
        }
        else
        {
            if (horizontal == 0)
            {
                _playerAnimations.Running(false);
            }
        }

        if (vertical < 0)
        {
            offset += transform.forward * vertical * _speed * Time.deltaTime;
            _playerAnimations.RunBack(true);
        }

        else
        {
            _playerAnimations.RunBack(false);
        }
        return offset;
    }

    private void Shooting()
    {
        _timeWait -= Time.deltaTime;
        _playerAnimations.Shooting(true);

        if (_timeWait < 0f)
        {
            _timeWait = 0.3f;
            _shooter.Shoot();
            _soundShooter.AudioShoot();
        }
    }

    private void MouseY(float _rotY)
    {
        if (_rotY != 0)
        {
            _camera.transform.localRotation = Quaternion.Euler(_rotY, 0, 0);
        }
    }

    private void MouseX(float mouseX)
    {
        if (mouseX != 0)
        {
            transform.Rotate(transform.up * mouseX * _rotateSpeed * Time.deltaTime);
        }
    }
}
