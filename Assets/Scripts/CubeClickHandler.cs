using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private List<Cube> _spawnedCubes;

    private void OnEnable()
    {
        _raycaster.CubeClicked += ProcessClick;
    }
    private void OnDisable()
    {
        _raycaster.CubeClicked -= ProcessClick;
    }

    private void ProcessClick(Cube cube)
    {
        if (cube.TrySplit())
        {
            _spawnedCubes = _cubeSpawner.SpawnCubes(cube);
            _exploder.Explode(_spawnedCubes, cube.transform.position);
        }
        else
        {
            _exploder.ExplodeAround(cube.transform.position, cube.Scale);
        }
    }
}
