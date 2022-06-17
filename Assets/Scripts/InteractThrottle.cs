using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractThrottle : MonoBehaviour
{
    private ExtraInputs _extraInputs;

    [SerializeField] private Animator _animator;

    private StarterAssetsInputs _input;

    private Camera _camera;
    [SerializeField] private float _throttleAmount;
    [SerializeField] [Range(1f, 10f)] private float _sensitivity = 2f;

    private bool _mouseOver;
    [SerializeField] private bool _canManipulate;

    private void Awake()
    {
        _extraInputs = new ExtraInputs();
        _extraInputs.Enable();

        _extraInputs.ExtraInputMap.Grab.started += _ =>
        {
            if (_mouseOver)
                _canManipulate = true;
        };
        _extraInputs.ExtraInputMap.Grab.canceled += _ => { _canManipulate = false; };
    }

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        _extraInputs.Disable();
    }

    private void SetThrottleAnim(float amount)
    {
        _animator.SetFloat("throttle", amount);
    }

    private void Update()
    {
        MouseOver();
        SetThrottleAnim(_throttleAmount);

        if (_canManipulate)
        {
            SetThrottle();
        }
    }

    private void MouseOver()
    {
        var ray = _camera.ScreenPointToRay(_input.drag);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null) //change this to a generic type
                _mouseOver = true;
        }
        else
        {
            _mouseOver = false;
        }
    }

    private void SetThrottle()
    {
        _throttleAmount += -_input.look.x * _sensitivity * .01f;
        _throttleAmount = Mathf.Clamp(_throttleAmount, 0f, 1f - .01f);
    }
}