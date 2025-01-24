using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour, IPlayerComponent
{
    public void UpdateComponent()
    {
        
    }

    private void OnAttack(InputValue value)
    {
        Debug.Log("We're attacking");
    }
}
