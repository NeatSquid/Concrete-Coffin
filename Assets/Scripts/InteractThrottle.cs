using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractThrottle : MonoBehaviour
{
    private Mouse _mouse; // do your best to avoid having an input device.

    [SerializeField] private Animator _animator;

    private StarterAssetsInputs _input;

    private Camera _camera;
    [SerializeField] private float _throttleAmount;
    [SerializeField] [Range(1f, 10f)] private float _sensitivity = 2f;

    private bool _mouseOver;
    [SerializeField] private bool _canManipulate;

    private void Start()
    {
        _mouse = Mouse.current;
        _input = GetComponent<StarterAssetsInputs>();
        _camera = Camera.main;
    }

    private void SetThrottle(float amount)
    {
        _animator.SetFloat("throttle", amount);
    }

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(_mouse.position.ReadValue());
        SetThrottle(_throttleAmount);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider != null)
                _mouseOver = true;
        }
        else
        {
            _mouseOver = false;
        }

        Manipulation();

        if (_canManipulate)
        {
            MoveHandle();
        }
    }

    private void Manipulation()
    {
        if (_mouseOver && _mouse.leftButton.isPressed)
        {
            _canManipulate = true;
        }

        if (_mouse.leftButton.wasReleasedThisFrame)
        {
            _canManipulate = false;
        }
    }

    private void MoveHandle()
    {
        _throttleAmount += -_input.look.x * _sensitivity * .01f;
        _throttleAmount = Mathf.Clamp(_throttleAmount, 0f, 1f - .01f);
    }
}