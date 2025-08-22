using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseClicked;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked?.Invoke();
        }
    }
}
