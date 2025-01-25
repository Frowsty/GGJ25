using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;
    public bool shouldDestroy = false;
    public int damage = 10;
    public float spawnTime;

    public void UpdateBullet()
    {
        transform.position += speed * Time.deltaTime * direction;
        
        // destroy after x lifetime
        if (Time.time - spawnTime >= 2f)
            shouldDestroy = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerStats.Instance.SetHealth(PlayerStats.Instance.GetHealth() - damage);
            shouldDestroy = true;
        }
    }
}
