using UnityEngine;

public class ObjectHighlighter : MonoBehaviour, IInteractable
//so far this thing just changes current material color to white
{
    private Material _material;

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public string GetDescription()
    {
        return "Change to white";
    }

    public void Interact()
    {
        _material.color = Color.white;
    }
}