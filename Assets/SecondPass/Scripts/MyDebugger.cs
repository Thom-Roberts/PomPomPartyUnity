using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDebugger : MonoBehaviour
{
    [SerializeField]
    private InputManager _inputManager = default;

    private void Awake()
    {
        _inputManager.debugEvent += () => print("Hello");
    }
}
