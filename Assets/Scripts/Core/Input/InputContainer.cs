using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputContainer : MonoBehaviour
{
    private InputUser _inputAction;

    public InputUser InputAction => _inputAction;

    private void Awake()
    {
        _inputAction = new InputUser();
    }

    private void OnDisable()
    {
        _inputAction.Disable();
    }

    private void OnEnable()
    {
        _inputAction.Enable();
    }
}
