using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public bool shouldDie = false;

    private float speed = 2f;
    private StatBase stats;

    private void Start()
    {
        stats = GetComponent<StatBase>();
        speed = stats.GetMovementSpeed();
    }
    
    public void UpdateEnemy()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * direction;
    }

    public void TakeDamage(float damage)
    {
        stats.SetHealth(Mathf.RoundToInt(stats.GetHealth() - damage));

        if (stats.GetHealth() <= 0)
            shouldDie = true;
    }
}
