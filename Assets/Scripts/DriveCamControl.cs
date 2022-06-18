using StarterAssets;
using UnityEngine;

public class DriveCamControl : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _inputs;

    private void Update()
    {
        var turn = new Vector3(_inputs.look.y, _inputs.look.x, 0f);
        transform.Rotate(turn, Space.Self);
        // transform.localRotation = Quaternion.Euler(turn);
    }
}