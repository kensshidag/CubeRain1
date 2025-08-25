using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForse = 400;
    [SerializeField] private float _explosionRadius = 3;

    private float _multiplier = 0;

    private Rigidbody _rigidbody;
    public void Explode(List<Cube> cubes, Vector3 explosionPosition)
    {
        foreach (var cube in cubes)
        {
            if (cube.TryGetComponent<Rigidbody>(out _rigidbody))
            {
                _rigidbody.AddExplosionForce(_explosionForse, explosionPosition, _explosionRadius);
            }
        }
    }

    public void ExplodeAround(Vector3 explosionPosition, Vector3 scale)
    {
        _multiplier = 1 - (scale.x * scale.y * scale.z) + 1;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, _explosionRadius * _multiplier);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Rigidbody>(out _rigidbody))
            {
                _rigidbody.AddExplosionForce(_explosionForse * _multiplier, explosionPosition, _explosionRadius * _multiplier);
            }
        }

        _multiplier = 0;
    }
}
