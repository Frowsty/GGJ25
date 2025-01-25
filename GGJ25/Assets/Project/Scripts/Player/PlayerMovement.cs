using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb2d;
    private Animator animator;

    private void Start()
    {
        if (rb2d == null)
            rb2d = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
    }

    public void UpdateComponent()
    {
        SetAnimationStates();
        rb2d.linearVelocity = direction * PlayerStats.Instance.GetMovementSpeed();
    }

    public void SetAnimationStates()
    {
        if (direction.x > 0 && (direction.y >= 0 || direction.y <= 0))
        {
            animator.SetBool("WalkingRight", true);
            animator.SetBool("WalkingBack", false);
            animator.SetBool("WalkingFront", false);
            animator.SetBool("WalkingLeft", false);
        }
        else if (direction.x < 0 && (direction.y >= 0 || direction.y <= 0))
        {
            animator.SetBool("WalkingLeft", true);
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingBack", false);
            animator.SetBool("WalkingFront", false);
        }
        else if (direction.x == 0 && direction.y > 0)
        {
            animator.SetBool("WalkingBack", true);
            animator.SetBool("WalkingFront", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
        }
        else if (direction.x == 0 && direction.y < 0)
        {
            animator.SetBool("WalkingFront", true);
            animator.SetBool("WalkingBack", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
        }
        else
        {
            animator.SetBool("WalkingBack", false);
            animator.SetBool("WalkingFront", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
