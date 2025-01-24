using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour, IPlayerComponent
{
    [SerializeField]
    private BubbleMovement bubblePrefab;

    public List<BubbleMovement> bubbles;

    public void UpdateComponent()
    {
        for (int i = bubbles.Count - 1; i >= 0; i--)
        {
            bubbles[i].UpdateBubble();
            if (bubbles[i].shouldDestroy)
            {
                Destroy(bubbles[i].gameObject);
                bubbles.RemoveAt(i);
            }
        }
    }

    private void OnAttack(InputValue value)
    {
        var bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        direction.Normalize();
        bubble.direction = direction; 
        bubble.spawnTime = Time.time;
        bubbles.Add(bubble);
    }
}
