using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _crossHair;

    private int damage = 5;

    private RaycastHit GetRaycastHit()
    {
        var ray = _camera.ScreenPointToRay(_crossHair.transform.position);
        Physics.Raycast(ray, out RaycastHit hit, float.PositiveInfinity);
        return hit;
    }

    public void Shoot(/*Transform shootPoint*/)
    {
        if (GetRaycastHit().collider.TryGetComponent(out Zombie zombie))
        {
            zombie.TakeDamage(damage);
        }
    }
}
