using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimations _playerAnimations;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private CharacterController _controller;

    public Vector3 Direction(float horizontal, float vertical)
    {
        Vector3 offset = Vector3.zero;
        offset += transform.right * horizontal * _speed * Time.deltaTime;
        offset += transform.forward * vertical * _speed * Time.deltaTime;
        offset += Physics.gravity * Time.deltaTime;
        _controller.Move(offset);
        _playerAnimations.ToMove(vertical);
        _playerAnimations.ToStrafe(horizontal);
        return offset;
    }
}
