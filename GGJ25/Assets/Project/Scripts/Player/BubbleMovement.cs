using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    private float lifeTime = 2f;
    private float bubbleSpeed = 15f;

    public float spawnTime;
    public bool shouldDestroy = false;
    public Vector3 direction;
    
    public void UpdateBubble()
    {
        transform.position +=  bubbleSpeed * Time.deltaTime * direction;
        if (Time.time - spawnTime >= lifeTime)
            shouldDestroy = true;
    }
}
