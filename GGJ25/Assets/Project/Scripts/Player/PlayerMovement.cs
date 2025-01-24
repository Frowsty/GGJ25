using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb2d;
    private float speed = 10f;

    private void Start()
    {
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();
    }

    public void UpdateComponent()
    {
        rb2d.linearVelocity = direction * speed;
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
