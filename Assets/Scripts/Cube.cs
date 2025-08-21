using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;

    public event Action<Cube> SplitRequested;

    private float _scaleDivider = 2.0f;
    private float _chanceDivider = 2.0f;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void TrySplit()
    {
        if (_splitChance >= UnityEngine.Random.value)
        {
            SplitRequested?.Invoke(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }      

    public void Initialize()
    {
        _splitChance /= _chanceDivider;
        transform.localScale /= _scaleDivider;
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}
