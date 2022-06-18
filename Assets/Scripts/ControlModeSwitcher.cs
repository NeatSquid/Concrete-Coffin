using StarterAssets;
using UnityEngine;

public class ControlModeSwitcher : MonoBehaviour
{
    [SerializeField] private FirstPersonController _controller;
    [SerializeField] private GameObject _driveCam;

    private ExtraInputs _extraInputs;

    private void Awake()
    {
        _extraInputs = new ExtraInputs();
        _extraInputs.Enable();

        _extraInputs.ExtraInputMap.Interact.performed += _ =>
        {
            _controller.enabled = !_controller.enabled;
            _driveCam.gameObject.SetActive(!_driveCam.gameObject.activeSelf);
        };
    }

    private void OnDestroy()
    {
        _extraInputs.Disable();
    }
}