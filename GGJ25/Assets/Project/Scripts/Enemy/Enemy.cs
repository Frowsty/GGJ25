using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public bool shouldDie = false;

    private float speed = 5f;
    public void UpdateEnemy()
    {
        Vector3 direction = (Player.Instance.transform.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * direction;
    }
}
