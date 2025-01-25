using UnityEngine;

public class Shell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() + 1);
            Destroy(gameObject);
        }
    }
}
