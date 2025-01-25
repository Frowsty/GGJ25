using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleMovement : MonoBehaviour
{
    private float lifeTime = 2f;
    private float bubbleSpeed = 15f;

    public CircleCollider2D bubbleCollider;
    public float spawnTime;
    public bool shouldDestroy = false;
    public Vector3 direction;
    public float damage;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.Play();
    }

    public void UpdateBubble()
    {
        transform.position +=  bubbleSpeed * Time.deltaTime * direction;
        if (Time.time - spawnTime >= lifeTime)
            shouldDestroy = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            if (Random.value > PlayerStats.Instance.GetPiercingRate())
                shouldDestroy = true;
        }
    }
}
