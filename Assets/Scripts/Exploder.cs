using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForse = 45;
    [SerializeField] private float _explosionRadius = 5;
    public void Explode(List<Cube> cubes, Vector3 explosionPosition)
    {
        foreach (var cube in cubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForse, explosionPosition, _explosionRadius);
        }
    }
}
