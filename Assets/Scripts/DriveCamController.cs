using StarterAssets;
using UnityEngine;

public class DriveCamController : MonoBehaviour
{
    [SerializeField] private InteractionDrive _drive;
    [SerializeField] private StarterAssetsInputs _inputs;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector2 mouseViewportSpace;
    [SerializeField] private Transform _camTransfrom;

    [SerializeField] [Range(0f, 10f)] private float _edgeOffset = 1f;
    [SerializeField] private Vector2 _turn;

    private float _offsetMult = .01f;
    private Vector3 _originalEuler;

    private enum ViewEdge
    {
        Left,
        Right,
        Top,
        Bottom
    }

    private void Start()
    {
        _originalEuler = _camTransfrom.eulerAngles;
    }

    private void Update()
    {
        ProcessScreenEdge();
    }

    private void TurnCam(ViewEdge edge)
    {
        var xPositive = _inputs.look.x < 0f;
        var xNegative = _inputs.look.x > 0f;
        var yPositive = _inputs.look.y < 0f;
        var yNegative = _inputs.look.y > 0f;

        switch (edge)
        {
            case ViewEdge.Left:
                if (xPositive)
                    _turn.y += _inputs.look.x;
                break;
            case ViewEdge.Right:
                if (xNegative)
                    _turn.y += _inputs.look.x;
                break;
            case ViewEdge.Top:
                if (yPositive)
                    _turn.x += _inputs.look.y;
                break;
            case ViewEdge.Bottom:
                if (yNegative)
                    _turn.x += _inputs.look.y;
                break;
        }

        _camTransfrom.eulerAngles = _originalEuler + (Vector3)_turn;
    }

    private void ProcessScreenEdge()
    {
        mouseViewportSpace = _camera.ScreenToViewportPoint(_inputs.drag);

        var minValue = _edgeOffset * _offsetMult;
        var maxValue = 1f - _edgeOffset * _offsetMult;

        if (_drive._manipulating) return;

        if (mouseViewportSpace.x < minValue)
            TurnCam(ViewEdge.Left);
        else if (mouseViewportSpace.x > maxValue)
            TurnCam(ViewEdge.Right);

        if (mouseViewportSpace.y > maxValue)
            TurnCam(ViewEdge.Top);
        else if (mouseViewportSpace.y < minValue)
            TurnCam(ViewEdge.Bottom);

        // don't turn it back also don't turn it while operating handle.
        // garbage implementation but it'll do for now.
    }
}