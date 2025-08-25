using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _cubeLayer;

    public event Action<Cube> CubeClicked;

    private Ray _ray;
    private Cube _cube;

    private void OnEnable()
    {
        _inputReader.MouseClicked += HitRaycast;
    }
    private void OnDisable()
    {
        _inputReader.MouseClicked -= HitRaycast;
    }

    private void HitRaycast()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity, _cubeLayer))
        {
            if (hit.collider.TryGetComponent<Cube>(out _cube))
            {
                CubeClicked?.Invoke(_cube);
            }                    
        }
    }
}
