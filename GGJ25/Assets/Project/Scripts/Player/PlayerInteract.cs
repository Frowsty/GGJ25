using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour, IPlayerComponent
{
    public bool canInteract = false;

    private void Awake()
    {
        canInteract = false;
    }

    public void UpdateComponent()
    {
        if (canInteract && InputSystem.actions["Interact"].WasPressedThisFrame())
            Debug.Log("Open merchant menu");
    }
}
