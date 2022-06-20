using TMPro;
using UnityEngine;

public class InteractionFirstPerson : MonoBehaviour
{
    private ExtraInputs _extraInputs;

    [SerializeField] private Camera _mainCam;
    [SerializeField] private float _interactionDistance = 2f;

    [SerializeField] private GameObject _interactionUI;
    [SerializeField] private TextMeshProUGUI _interactionText;

    private void Awake()
    {
        _extraInputs = new ExtraInputs();
        _extraInputs.Enable();
    }

    private void OnDestroy()
    {
        _extraInputs.Disable();
    }

    private void Update()
    {
        InteractionRay();
    }

    private void InteractionRay()
    {
        var mouseOver = false;

        var ray = _mainCam.ViewportPointToRay(Vector3.one / 2f);
        if (Physics.Raycast(ray, out var hit, _interactionDistance))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable == null) return;

            mouseOver = true;

            _interactionText.text = interactable.GetDescription();

            if (_extraInputs.ExtraInputMap.Interact.WasPressedThisFrame())
            {
                interactable.Interact();
            }
        }

        _interactionUI.SetActive(mouseOver); //bug with extended display of this gameObject
    }
}