using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public event UnityAction MouseDown;
    public event UnityAction MouseUp;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDown?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseUp?.Invoke();
        }

        _direction = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        _mouseY -= _direction.y * _sensivity;
        _mouseY = Mathf.Clamp(_mouseY, -_rotate, _rotate);
        _inputCamera.SetDirectionX(_direction.x);
        _inputCamera.SetDirectionY(_mouseY);
    }
}
