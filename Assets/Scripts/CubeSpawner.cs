using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _cubeLayer;
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private int _minCubeSpawnCount = 2;
    [SerializeField] private int _maxCubeSpawnCount = 6;

    private Ray _ray;

    private void Start()
    {
        foreach (var cube in _cubes)
        {
            cube.SplitRequested += SpawnCubes;
        }
    }

    private void Update()
    {
        ClickToCube();
    }

    private void ClickToCube()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity, _cubeLayer))
            {
                Cube cube = hit.transform.GetComponent<Cube>();
                cube.TrySplit();
            }
        }
    }

    private void SpawnCubes(Cube cube)
    {
        UnregisterCube(cube);
        
        int cubesToSpawnCount = UnityEngine.Random.Range(_minCubeSpawnCount, _maxCubeSpawnCount + 1); 

        for (int i = 0; i < cubesToSpawnCount; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            newCube.Initialize();
            RegisterCube(newCube);
        }    
        
        Destroy(cube.gameObject);
    }

    private void RegisterCube(Cube cube)
    {
        if (!_cubes.Contains(cube))
        {
            _cubes.Add(cube);
            cube.SplitRequested += SpawnCubes;
        }
    }

    private void UnregisterCube(Cube cube)
    {
        if (_cubes.Contains(cube))
        {
            _cubes.Remove(cube);
            cube.SplitRequested -= SpawnCubes;
        }
    }
}
