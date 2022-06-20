using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControl : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private ExtraInputs _extraInputs;

    private void Awake()
    {
        _extraInputs = new ExtraInputs();
        _extraInputs.Enable();

        _extraInputs.ExtraInputMap.Interact.performed += _ => { _playerInput.enabled = !_playerInput.enabled; };
    }

    private void OnDestroy()
    {
        _extraInputs.Disable();
    }
}