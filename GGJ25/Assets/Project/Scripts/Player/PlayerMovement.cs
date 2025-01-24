using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Vector2 direction = Vector2.zero;

    public void UpdateComponent()
    {
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
