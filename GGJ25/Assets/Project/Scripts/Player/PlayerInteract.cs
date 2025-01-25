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
            Merchant.Instance.ShowMerchantMenu();
        
        if (Input.GetKeyDown(KeyCode.H))
            EnemySpawner.Instance.SpawnEnemy(transform.position + new Vector3(5f, 5f, 0));
    }
}
