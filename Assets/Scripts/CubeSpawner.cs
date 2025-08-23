using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCubeSpawnCount = 2;
    [SerializeField] private int _maxCubeSpawnCount = 6;

    public List<Cube> SpawnCubes(Cube cube)
    {
        List<Cube> newCubes = new();
        int cubesToSpawnCount = Random.Range(_minCubeSpawnCount, _maxCubeSpawnCount + 1); 

        for (int i = 0; i < cubesToSpawnCount; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            newCubes.Add(newCube);
            newCube.Initialize();
        }
       
        Destroy(cube.gameObject);
        return newCubes;
    }
}
