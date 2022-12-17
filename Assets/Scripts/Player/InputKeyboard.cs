using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private Vector2 _direction;

    private void Update()
    {
        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _playerMovement.Direction(_direction.x, _direction.y);
    }
}
