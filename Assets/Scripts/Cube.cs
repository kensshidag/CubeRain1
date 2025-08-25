using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1.0f;

    public Vector3 Scale { get; private set; }

    private float _scaleDivider = 2.0f;
    private float _chanceDivider = 2.0f;
    private Renderer _renderer;

    private void Awake()
    {
        Scale = transform.localScale;
        _renderer = GetComponent<Renderer>();
    }

    public bool TrySplit()
    {
        if (_splitChance >= UnityEngine.Random.value)
        {
            return true;
        }
        else
        {
            Destroy(gameObject);
            return false;
        }
    }      

    public void Initialize()
    {
        _splitChance /= _chanceDivider;
        transform.localScale /= _scaleDivider;
        Scale = transform.localScale;
        _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
    }
}
