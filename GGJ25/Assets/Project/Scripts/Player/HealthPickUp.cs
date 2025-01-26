using System;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float percentageHeal = 0.15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            PlayerStats.Instance.SetHealth(Mathf.RoundToInt(PlayerStats.Instance.GetHealth() +
                                                            PlayerStats.Instance.GetMaxHealth() * percentageHeal));
            Destroy(gameObject);
        }
        
        
    }
}
