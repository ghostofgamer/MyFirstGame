using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private float _rotateSpeed = 180f;

    public void SetDirectionY(float mouseY)
    {
        if (mouseY != 0)
        {
            _camera.transform.localRotation = Quaternion.Euler(mouseY, 0, 0);
        }
    }

    public void SetDirectionX(float mouseX)
    {
        if (mouseX != 0)
        {
            transform.Rotate(transform.up * mouseX * _rotateSpeed * Time.deltaTime);
        }
    }
}
