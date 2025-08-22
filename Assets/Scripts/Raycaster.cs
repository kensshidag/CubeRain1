using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _cubeLayer;

    public event Action<Cube> OnCubeClicked;

    private Ray _ray;

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
            Cube cube = hit.collider.GetComponent<Cube>();
            OnCubeClicked?.Invoke(cube);
        }
    }
}
