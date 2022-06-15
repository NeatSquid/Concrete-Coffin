using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private Keyboard _keyboard;

    [SerializeField] private Camera _mainCam;
    [SerializeField] private float _interactionDistance = 2f;

    [SerializeField] private GameObject _interactionUI;
    [SerializeField] private TextMeshProUGUI _interactionText;

    private void Awake()
    {
        _keyboard = Keyboard.current;
    }

    private void Update()
    {
        InteractionRay();
    }

    private void InteractionRay()
    {
        var hitSomething = false;

        var ray = _mainCam.ViewportPointToRay(Vector3.one / 2f);
        if (Physics.Raycast(ray, out var hit, _interactionDistance))
        {
            var interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable == null) return;

            hitSomething = true;
            _interactionText.text = interactable.GetDescription();

            if (_keyboard.eKey.wasPressedThisFrame) //press interact button
            {
                interactable.Interact();
            }
        }

        _interactionUI.SetActive(hitSomething); //bug with extended display of this gameObject
    }
}