using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour, IEnemy
{
    public bool shouldDie = false;

    private float speed = 2f;
    private StatBase stats;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    
    
    [SerializeField]
    private Bullet bulletPrefab;

    private float fireRate = 1f;
    private float lastShot = 0f;
    
    List<Bullet> bullets = new();

    public enum EnemyType
    {
        Melee,
        Ranged
    }

    public EnemyType eType;
    
    private void Start()
    {
        stats = GetComponent<StatBase>();
        speed = stats.GetMovementSpeed();
        
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    public void UpdateEnemy()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        rb2d.linearVelocity = speed * direction;
        switch (eType)
        {
            case EnemyType.Ranged:
                if (Vector3.Distance(Player.Instance.transform.position, transform.position) <= 7f)
                    rb2d.linearVelocity = Vector3.zero;
                break;
        }

        if (Time.time - lastShot >= fireRate)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.direction = direction;
            bullet.spawnTime = Time.time;
            bullets.Add(bullet);
            
            lastShot = Time.time;
        }

        for (int i = bullets.Count - 1; i >= 0; i--)
        {
            bullets[i].UpdateBullet();
            
            if (bullets[i].shouldDestroy)
            {
                Destroy(bullets[i].gameObject);
                bullets.RemoveAt(i);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        stats.SetHealth(Mathf.RoundToInt(stats.GetHealth() - damage));
        
        Sequence sequence = DOTween.Sequence();
        sequence.Append(sr.DOColor(Color.red, 0.2f));
        sequence.Append(sr.DOColor(Color.white, 0.2f));
        
        if (stats.GetHealth() <= 0)
        {
            shouldDie = true;
            foreach (Bullet bullet in bullets)
                Destroy(bullet.gameObject);
            bullets.Clear();
        }
        
    }
}
