using UnityEngine;

public class CustomizeCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}