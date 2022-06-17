using StarterAssets;
using UnityEngine;

public class InteractionControl : MonoBehaviour
{
    private ExtraInputs _extraInputs;

    [SerializeField] private Animator _animator;

    [SerializeField] private StarterAssetsInputs _input;

    private Camera _camera;
    [SerializeField] private float _throttleAmount;
    [SerializeField] [Range(1f, 10f)] private float _sensitivity = 2f;

    [SerializeField] private bool _mouseOver;
    [SerializeField] private bool _manipulating;

    private void Awake()
    {
        _extraInputs = new ExtraInputs();
        _extraInputs.Enable();

        _extraInputs.ExtraInputMap.Grab.started += _ =>
        {
            if (_mouseOver)
                _manipulating = true;
        };
        _extraInputs.ExtraInputMap.Grab.canceled += _ => { _manipulating = false; };
    }

    private void Start()
    {
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

        if (_manipulating)
        {
            SetThrottle();
        }
    }

    private void MouseOver()
    {
        var ray = _camera.ScreenPointToRay(_input.drag);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();

            _mouseOver = interactable != null;
        }
    }

    private void SetThrottle()
    {
        _throttleAmount += -_input.look.x * _sensitivity * .01f;
        _throttleAmount = Mathf.Clamp(_throttleAmount, 0f, 1f - .01f);
    }
}