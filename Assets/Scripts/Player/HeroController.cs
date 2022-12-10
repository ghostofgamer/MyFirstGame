using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Transform _point;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shootClip;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _camera;

    private float _timeWait = 0.3f;
    private float _rotateSpeed = 180f;
    private float _rotY;
    private float _rotate = 80f;
    private int _sensivity = 3;

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 offset = Vector3.zero;

        _rotY -= Input.GetAxis("Mouse Y") * _sensivity;
        _rotY = Mathf.Clamp(_rotY, -_rotate, _rotate);

        if (_rotY != 0)
        {
            _camera.transform.localRotation = Quaternion.Euler(_rotY, 0, 0);
        }

        if (horizontal != 0)
        {
            offset = transform.right * horizontal * _speed * Time.deltaTime;
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
        _timeWait -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            _animator.SetBool("Shoot", true);

            if (_timeWait < 0f)
            {
                _timeWait = 0.3f;
                _shooter.Shoot(_point);
                _audioSource.PlayOneShot(_shootClip);
            }
        }
        else
        {
            _animator.SetBool("Shoot", false);
        }

        if (vertical > 0)
        {
            offset += transform.forward * vertical * _speed * Time.deltaTime;
            _animator.SetBool("Run", true);
        }
        else
        {
            if (horizontal == 0)
            {
                _animator.SetBool("Run", false);
            }
        }

        if (vertical < 0)
        {
            offset += transform.forward * vertical * _speed * Time.deltaTime;
            _animator.SetBool("Back", true);
        }

        else
        {
            _animator.SetBool("Back", false);
        }

        if (mouseX != 0)
        {
            transform.Rotate(transform.up * mouseX * _rotateSpeed * Time.deltaTime);
        }
        offset += Physics.gravity * Time.deltaTime;
        _controller.Move(offset);
    }
}
