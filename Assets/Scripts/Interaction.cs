using UnityEngine;

public class Interaction : MonoBehaviour, IInteractable
{
    private string _name;

    private void Awake()
    {
        _name = gameObject.name;
    }

    public void Interact()
    {
        print($"Interaction with {_name} registered");
    }

    public string GetDescription()
    {
        return "Interact";
    }
}