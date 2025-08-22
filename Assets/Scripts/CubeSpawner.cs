using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private int _minCubeSpawnCount = 2;
    [SerializeField] private int _maxCubeSpawnCount = 6;

    public List<Cube> SpawnCubes(Cube cube)
    {
        _cubes.Remove(cube);

        List<Cube> newCubes = new();
        int cubesToSpawnCount = UnityEngine.Random.Range(_minCubeSpawnCount, _maxCubeSpawnCount + 1); 

        for (int i = 0; i < cubesToSpawnCount; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            newCubes.Add(newCube);
            newCube.Initialize();
            _cubes.Add(cube);
        }
       
        Destroy(cube.gameObject);
        return newCubes;
    }
}
